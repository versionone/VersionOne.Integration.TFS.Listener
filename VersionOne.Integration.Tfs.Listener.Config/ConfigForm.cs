using System;
using System.Collections;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using VersionOne.Integration.Tfs.Core.DataLayer;
using VersionOne.Integration.Tfs.Core.DTO;
using VersionOne.Integration.Tfs.Core.Extensions;
using VersionOne.Integration.Tfs.Core.Security;
using VersionOne.Integration.Tfs.Core.Structures;
using HttpClient = System.Net.Http.HttpClient;

namespace VersionOne.Integration.Tfs.Listener.Config
{
    public partial class ConfigForm : Form
    {

        internal static TfsTeamProjectCollection TfsServer;

        public ConfigForm()
        {

            InitializeComponent();

            btnTestV1Connection.Click += btnTestV1Connection_Click;
            btnSaveAllSettings.Click += btnSaveVersionOneSettings_Click;
            btnSetBaseListenerUrl.Click += UpdateForm;
            TFSConnectB.Click += TFSConnectB_Click;
            TFSUpdateB.Click += TFSUpdateB_Click;
            UnsubscribeB.Click += UnsubscribeB_Click;
            TFSTestEventsB.Click += TFSTestEventsB_Click;
            chkUseProxy.CheckedChanged += chkUseProxy_CheckedChanged;
            UseIntegratedAuthenticationCB.CheckedChanged += chkUseIntegrationAuth_CheckChanged;

            UpdateForm(null, null);

        }

        private void UpdateForm(object sender, EventArgs e)
        {

            var config = GetConfigurationData();

            //Advanced setup
            RegExTB.Text = config.TfsWorkItemRegex;

            txtDebugDescription.Text = string.Format("Debug information is written to {0}", Paths.LoggingPath);

            //V1 setup
            V1URLTB.Text = config.VersionOneUrl;

            V1UsernameTB.Text = config.VersionOneUserName;
            V1PasswordTB.Text = config.VersionOnePassword;
            UseIntegratedAuthenticationCB.Checked = config.IsWindowsIntegratedSecurity;

            chkUseProxy.Checked = config.ProxyIsEnabled;
            txtProxyUrl.Text = config.ProxyUrl;
            txtProxyUsername.Text = config.ProxyUsername;
            txtProxyPassword.Text = config.ProxyPassword;
            txtProxyDomain.Text = config.ProxyDomain;
            SetProxyRelatedFieldsEnabled(config.ProxyIsEnabled);

            //TFS setup
            TFSURLTB.Text = config.TfsUrl;
            TFSUsernameTB.Text = config.TfsUserName;
            TFSPasswordTB.Text = config.TfsPassword;
            try
            {
                ListenerURLTB.Text = new Uri(config.BaseListenerUrl).Append(UriElements.ServiceName).ToString();
            }
            catch
            {
                ListenerURLTB.Text = new Uri(new ConfigurationProxy().BaseListenerUrl).Append(UriElements.ServiceName).ToString();
            }

            // Overall
            tbBaseUrl.Text = config.BaseListenerUrl;

            // Debug Mode
            chkDebugMode.Checked = config.DebugMode;
            UpdateFormControlStatus();
        }

        private TfsServerConfiguration GetConfigurationData()
        {

            if (tcSettings.Enabled == false) tcSettings.Enabled = true;
            if (btnSaveAllSettings.Enabled == false) btnSaveAllSettings.Enabled = true;

            var tfsConfig = new TfsServerConfiguration();
            ConfigurationProxy proxy;
            try
            {
                proxy = new ConfigurationProxy(null, tfsConfig.BaseListenerUrl);
            }
            catch
            {
                proxy = new ConfigurationProxy(null, tbBaseUrl.Text);
            }

            UpdateStatusText(string.Format("Updating configuration information from {0}.", proxy.ConfigurationUrl), false);

            try
            {
                tfsConfig = proxy.Retrieve(ProtectData.Unprotect);
            }
            catch (Exception e)
            {
                UpdateStatusText(string.Format("Could not use the TFS Listener at url {0}.  Exception:  {1}.", proxy.ConfigurationUrl, e.Message), true);
                tcSettings.Enabled = false;
                btnSaveAllSettings.Enabled = false;
            }
            finally
            {
                tbBaseUrl.Text = proxy.BaseListenerUrl;
            }

            return tfsConfig;

        }

        private void SetProxyRelatedFieldsEnabled(bool enabled)
        {
            txtProxyUrl.Enabled = txtProxyUsername.Enabled = txtProxyPassword.Enabled = txtProxyDomain.Enabled = enabled;
        }

        #region Event Handlers

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            SetProxyRelatedFieldsEnabled(chkUseProxy.Checked);
        }

        private void btnSaveVersionOneSettings_Click(object sender, EventArgs e)
        {

            var configToSave = new TfsServerConfiguration()
                {
                    VersionOneUrl = V1URLTB.Text,
                    VersionOneUserName = V1UsernameTB.Text,
                    VersionOnePassword = V1PasswordTB.Text,
                    TfsUrl = TFSURLTB.Text,
                    TfsUserName = TFSUsernameTB.Text,
                    TfsPassword = TFSPasswordTB.Text,
                    TfsWorkItemRegex = RegExTB.Text,
                    DebugMode = chkDebugMode.Checked,
                    IsWindowsIntegratedSecurity = UseIntegratedAuthenticationCB.Checked,
                    ProxyIsEnabled = chkUseProxy.Checked,
                    ProxyUrl = txtProxyUrl.Text,
                    ProxyUsername = txtProxyUsername.Text,
                    ProxyPassword = txtProxyPassword.Text,
                    ProxyDomain = txtProxyDomain.Text,
                    BaseListenerUrl = tbBaseUrl.Text,
                    WebSiteName = Utils.WebSiteName(ProtectData.Unprotect)
                };

            var results = new ConfigurationProxy().Store(configToSave);
            if (results != null && results[StatusKey.Status] == StatusCode.Ok)
            {
                try
                {
                    ListenerURLTB.Text = new Uri(configToSave.BaseListenerUrl).Append(UriElements.ServiceName).ToString();
                }
                catch
                {
                    ListenerURLTB.Text = new Uri(new ConfigurationProxy().BaseListenerUrl).Append(UriElements.ServiceName).ToString();
                }
                UpdateStatusText("Save successful.", false);
                return;
            }

            if (results == null) throw new Exception("Unable to retrieve results from server.");

            var missingFields = string.Join(", ", results.Keys.Where(key => key != "status"));
            var text = string.Format("The following values must be present in order to save settings:  {0}.", missingFields);
            UpdateStatusText(text, true);
        }

        private void btnTestV1Connection_Click(object sender, EventArgs e)
        {

            UpdateStatusText("Connecting to " + V1URLTB.Text + "...", false);

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var versionOneSettings = new VersionOneSettings()
                {
                    Path = V1URLTB.Text,
                    Username = V1UsernameTB.Text,
                    Password = V1PasswordTB.Text,
                    Integrated = UseIntegratedAuthenticationCB.Checked,
                    ProxySettings = GetProxySettings()
                };

                var v1Component = new V1Component(versionOneSettings);
                var connectionStatus = v1Component.ValidateConnection();
                DisplayConnectionValidationStatus(connectionStatus);
            }
            catch (Exception ex)
            {
                DisplayConnectionValidationStatus(false, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateStatusText(string text, bool isError)
        {
            tbResults.BackColor = isError ? Color.DarkRed : Color.DarkGreen;
            tbResults.Text = string.Concat(string.Format("({0}) {1}", DateTime.Now.ToLongTimeString(), text), Environment.NewLine) + tbResults.Text;
            tbResults.Refresh();
        }

        private void DisplayConnectionValidationStatus(bool status, string message = null)
        {
            if (!status)
            {
                UpdateStatusText(string.Format("Error connecting to {0}{1}", V1URLTB.Text, string.IsNullOrEmpty(message) ? string.Empty : ": " + message), true);
            }
            else
            {
                UpdateStatusText(string.Format("Successfully connected to {0}", V1URLTB.Text), false);
            }
        }

        private void TFSConnectB_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var proxy = new ConfigurationProxy();
                var config = proxy.Retrieve(ProtectData.Unprotect);

                config.TfsUrl = TFSURLTB.Text;
                config.TfsUserName = TFSUsernameTB.Text;
                config.TfsPassword = TFSPasswordTB.Text;

                proxy.Store(config);

                TFSStatusLabel.Text = "Not connected";

                TfsServer = null;
                // Connect to TFS
                TfsServer = Utils.ConnectToTFS();

                TFSStatusLabel.Text = "Connected to " + TFSURLTB.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                UpdateFormControlStatus();
            }
        }

        private void TFSUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var proxy = new ConfigurationProxy();
                var config = proxy.Retrieve(ProtectData.Unprotect);

                config.TfsUrl = ListenerURLTB.Text;
                proxy.Store(config);

                // Get Eventing Service
                var eventService = (IEventService)TfsServer.GetService(typeof(IEventService));

                // Set delivery preferences
                var dPref = new DeliveryPreference { Schedule = DeliverySchedule.Immediate, Address = config.TfsUrl, Type = DeliveryType.Soap };

                const string tag = "VersionOneTFSServer";

                // Unsubscribe to all events
                foreach (var s in eventService.GetEventSubscriptions(TfsServer.AuthorizedIdentity.Descriptor, tag))
                {
                    eventService.UnsubscribeEvent(s.ID);
                }

                // Subscribe to checked events
                var filter = string.Empty;
                eventService.SubscribeEvent("CheckinEvent", filter, dPref, tag);
                eventService.SubscribeEvent("BuildCompletionEvent2", filter, dPref, tag);

                UpdateFormControlStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UnsubscribeB_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TFSUnsubscribe();
                UpdateFormControlStatus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        private ProxyConnectionSettings GetProxySettings()
        {

            if (!chkUseProxy.Checked) return null;

            return new ProxyConnectionSettings
            {
                ProxyIsEnabled = chkUseProxy.Checked,
                Uri = new Uri(txtProxyUrl.Text),
                Username = txtProxyUsername.Text,
                Password = txtProxyPassword.Text,
                Domain = txtProxyDomain.Text
            };
        }

        private void UpdateFormControlStatus()
        {
            if (TfsServer != null)
            {
                //ListenerURLTB.Enabled = true;
                TFSUpdateB.Enabled = true;
                SubscriptionsLV.Enabled = true;
                UnsubscribeB.Enabled = true;
                TFSTestEventsB.Enabled = true;
                lblCurrentSubscriptions.Enabled = true;
                lblListenerUrl.Enabled = true;

                // Get Eventing Service
                var eventService = (IEventService)TfsServer.GetService(typeof(IEventService));

                // Subscribe to event
                const string tag = "VersionOneTFSServer";
                SubscriptionsLV.Items.Clear();

                foreach (var s in eventService.GetEventSubscriptions(TfsServer.AuthorizedIdentity.Descriptor, tag))
                {
                    var item = new ListViewItem(s.EventType.ToString());
                    item.SubItems.Add(s.DeliveryPreference.Address);
                    SubscriptionsLV.Items.Add(item);
                }

                if (SubscriptionsLV.Items.Count > 0)
                {
                    TFSUpdateB.Text = "Update Subscriptions";
                    UnsubscribeB.Enabled = true;
                    TFSTestEventsB.Enabled = true;
                }
                else
                {
                    TFSUpdateB.Text = "Subscribe";
                    UnsubscribeB.Enabled = false;
                    TFSTestEventsB.Enabled = false;
                }
            }
            else
            {
                SubscriptionsLV.Items.Clear();
                SubscriptionsLV.Items.Add(new ListViewItem("Not connected"));
                SubscriptionsLV.Enabled = false;
                //ListenerURLTB.Enabled = false;
                TFSUpdateB.Enabled = false;
                UnsubscribeB.Enabled = false;
                TFSTestEventsB.Enabled = false;
                lblCurrentSubscriptions.Enabled = false;
                lblListenerUrl.Enabled = false;
            }
        }

        public static void TFSUnsubscribe()
        {
            if (TfsServer == null)
            {
                TfsServer = Utils.ConnectToTFS();
            }

            // Get Eventing Service
            var eventService = (IEventService)TfsServer.GetService(typeof(IEventService));

            const string tag = "VersionOneTFSServer";

            // Unsubscribe to all events
            foreach (var s in eventService.GetEventSubscriptions(TfsServer.AuthorizedIdentity.Descriptor, tag))
            {
                eventService.UnsubscribeEvent(s.ID);
            }
        }

        public static void SetNetVersion(DirectoryEntry e, Version v)
        {
            var version = "Framework\\v" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "\\";

            var newMaps = new ArrayList();
            var versionRegex = new Regex(@"Framework\\v\d+\.\d+\.\d+\\", RegexOptions.IgnoreCase);

            var changed = false;

            foreach (string str in e.Properties["ScriptMaps"])
            {
                var temp = str;
                var match = versionRegex.Match(str);

                if (match.Success)
                {
                    if (match.Value != version)
                    {
                        temp = versionRegex.Replace(str, version);
                        changed = true;
                    }
                }
                newMaps.Add(temp);
            }

            if (changed)
            {
                e.Properties["ScriptMaps"].Value = newMaps.ToArray();
                e.CommitChanges();
            }
        }

        public static void Install()
        {
            var w3svc = new DirectoryEntry("IIS://localhost/w3svc");

            const string folder = "VersionOne TFS Listener";

            foreach (DirectoryEntry e in w3svc.Children)
            {
                if (e.SchemaClassName == "IIsWebServer" && e.Properties["ServerComment"].Value.ToString() == folder)
                {
                    SetNetVersion(e, Environment.Version);

                    foreach (DirectoryEntry f in e.Children)
                    {
                        if (f.SchemaClassName == "IIsWebVirtualDir")
                        {
                            SetNetVersion(f, Environment.Version);
                        }
                    }
                }
            }
        }

        private void chkUseIntegrationAuth_CheckChanged(object sender, EventArgs e)
        {
            //ToggleV1Credentials();
        }

        private byte _bit = 0;
        private void ToggleV1Credentials()
        {
            if (_bit == 0)
            {
                V1PasswordTB.Clear();
                V1UsernameTB.Text = GetWindowsUserName();
                _bit = 1;
            }
            else
            {
                var config = GetConfigurationData();
                V1PasswordTB.Text = config.VersionOnePassword;
                V1UsernameTB.Text = config.VersionOneUserName;
                _bit = 0;
            }
        }

        /// <summary>
        /// Formats the user name without the domain name.
        /// </summary>
        /// <returns></returns>
        private static string GetWindowsUserName()
        {
            const string backSlash = "\\";
            var identity = WindowsIdentity.GetCurrent();
            if (identity == null) return string.Empty;
            if (!identity.Name.Contains(backSlash)) return identity.Name;
            var index = identity.Name.IndexOf(backSlash, StringComparison.Ordinal);
            return identity.Name.Remove(0, (index + 1));
        }

        private void llClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbResults.Clear();
            tbResults.BackColor = Color.Black;
        }

        void TFSTestEventsB_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var soapCheckinComment = string.Format("SOAP TEST:{0}", Guid.NewGuid());
                var soapCheckinEventXml = string.Format(
@"&lt;?xml version=""1.0"" encoding=""utf-16""?&gt;&#xD;
&lt;CheckinEvent xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""&gt;&#xD;
  &lt;AllChangesIncluded&gt;true&lt;/AllChangesIncluded&gt;&#xD;
  &lt;Subscriber&gt;v1deploy&lt;/Subscriber&gt;&#xD;
  &lt;CheckinNotes /&gt;&#xD;
  &lt;CheckinInformation /&gt;&#xD;
  &lt;Artifacts&gt;&#xD;
  &lt;/Artifacts&gt;&#xD;
  &lt;Owner&gt;VM\v1deploy&lt;/Owner&gt;&#xD;
  &lt;OwnerDisplay&gt;v1deploy&lt;/OwnerDisplay&gt;&#xD;
  &lt;CreationDate&gt;2/4/2015 8:22:34 PM&lt;/CreationDate&gt;&#xD;
  &lt;Comment&gt;{0}&lt;/Comment&gt;&#xD;
  &lt;TimeZone&gt;Coordinated Universal Time&lt;/TimeZone&gt;&#xD;
  &lt;TimeZoneOffset&gt;00:00:00&lt;/TimeZoneOffset&gt;&#xD;
  &lt;TeamProject&gt;AnotherTeamProject&lt;/TeamProject&gt;&#xD;
  &lt;PolicyOverrideComment /&gt;&#xD;
  &lt;PolicyFailures /&gt;&#xD;
  &lt;Title&gt;AnotherTeamProject Changeset 1: Test Comnent S-01001&lt;/Title&gt;&#xD;
  &lt;ContentTitle&gt;Changeset 1: Test Comnent S-01001&lt;/ContentTitle&gt;&#xD;
  &lt;Committer&gt;VM\v1deploy&lt;/Committer&gt;&#xD;
  &lt;CommitterDisplay&gt;v1deploy&lt;/CommitterDisplay&gt;&#xD;
  &lt;Number&gt;1&lt;/Number&gt;&#xD;
&lt;/CheckinEvent&gt;", soapCheckinComment);

                var soapXml = string.Format(
@"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:a=""http://www.w3.org/2005/08/addressing"">
    <s:Header>
        <a:Action s:mustUnderstand=""1"">http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify</a:Action>
        <a:MessageID>urn:uuid:bcd69124-7da7-4e43-8b8f-427bf07731cf</a:MessageID>
        <a:ReplyTo>
        <a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>
        </a:ReplyTo>
        <a:To s:mustUnderstand=""1"">{0}</a:To>
    </s:Header>
    <s:Body>
        <Notify xmlns=""http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
            <eventXml>{1}</eventXml>
            <tfsIdentityXml />
        </Notify>
    </s:Body>
</s:Envelope>", ListenerURLTB.Text, soapCheckinEventXml);

                // Call listener web service with dummy checkin event
                UpdateStatusText("Making a test call to the TFS Listener directly and through TFS", false);
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("SOAPAction",
                        "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify");
                    var stringContent = new StringContent(soapXml, Encoding.UTF8, "application/soap+xml");
                    using (var response = httpClient.PostAsync(ListenerURLTB.Text, stringContent).Result)
                    {
                        //var soapResponse = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                            if (ValidateCheckinEventTest(soapCheckinComment))
                                UpdateStatusText("Direct connection to the TFS Listener was successful", false);
                            else
                                UpdateStatusText("Direct connection to the TFS Listener has failed", true);
                        else
                            UpdateStatusText(response.ReasonPhrase, true);
                    }
                }

                // Raise TFS dummy checkin event
                var tfsCheckinComment = string.Format("TFS TEST:{0}", Guid.NewGuid());
                var tfsCheckinEventXml = string.Format(
@"<?xml version=""1.0"" encoding=""utf-16""?>
<CheckinEvent xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <AllChangesIncluded>true</AllChangesIncluded>
  <Subscriber>v1deploy</Subscriber>
  <CheckinNotes />
  <CheckinInformation />
  <Artifacts>
  </Artifacts>
  <Owner>VM\v1deploy</Owner>
  <OwnerDisplay>v1deploy</OwnerDisplay>
  <CreationDate>2/4/2015 8:22:34 PM</CreationDate>
  <Comment>{0}</Comment>
  <TimeZone>Coordinated Universal Time</TimeZone>
  <TimeZoneOffset>00:00:00</TimeZoneOffset>
  <TeamProject>AnotherTeamProject</TeamProject>
  <PolicyOverrideComment />
  <PolicyFailures />
  <Title>AnotherTeamProject Changeset 1: Test Comnent S-01001</Title>
  <ContentTitle>Changeset 1: Test Comnent S-01001</ContentTitle>
  <Committer>VM\v1deploy</Committer>
  <CommitterDisplay>v1deploy</CommitterDisplay>
  <Number>1</Number>
</CheckinEvent>", tfsCheckinComment);

                var eventService = (IEventService)TfsServer.GetService(typeof(IEventService));
                eventService.FireEvent(tfsCheckinEventXml);

                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                var task = Task.Run(() =>
                {
                    while (!token.IsCancellationRequested &&
                        !ValidateCheckinEventTest(tfsCheckinComment))
                        Thread.Sleep(1000);
                }, token);
                if (task.Wait(30000, tokenSource.Token))
                    UpdateStatusText("TFS connection to the TFS Listener was successful", false);
                else
                {
                    tokenSource.Cancel();
                    UpdateStatusText("TFS connection to the TFS Listener has failed", true);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool ValidateCheckinEventTest(string checkinComment)
        {
            var filePath = Path.Combine(Paths.LoggingPath, "V1Debug.txt");
            return File.Exists(filePath) &&
                   File.ReadAllLines(filePath).Any(line => line.EndsWith(checkinComment));
        }
    }
}