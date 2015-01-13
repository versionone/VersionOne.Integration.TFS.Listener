using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using System;
using System.Collections;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VersionOne.Integration.Tfs.Core.DTO;
using VersionOne.Integration.Tfs.Core.Extensions;
using VersionOne.Integration.Tfs.Core.Structures;
using VersionOne.Integration.Tfs.Core.DataLayer;
using VersionOne.Integration.Tfs.Core.Security;
using Environment = System.Environment;

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

        private void SetProxyRelatedFieldsEnabled(bool enabled) {
            txtProxyUrl.Enabled = txtProxyUsername.Enabled = txtProxyPassword.Enabled = txtProxyDomain.Enabled = enabled;
        }

        #region Event Handlers

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e) {
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
            if(results != null && results[StatusKey.Status] == StatusCode.Ok)
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

            UpdateStatusText("Connecting to " + V1URLTB.Text+ "...", false);

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
            if(!status) 
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
                lblCurrentSubscriptions.Enabled = true;
                lblListenerUrl.Enabled = true;

                // Get Eventing Service
                var eventService = (IEventService) TfsServer.GetService(typeof(IEventService));

                // Subscribe to event
                const string tag = "VersionOneTFSServer";
                SubscriptionsLV.Items.Clear();
                
                foreach (var s in eventService.GetEventSubscriptions(TfsServer.AuthorizedIdentity.Descriptor,tag))
                {
                    var item = new ListViewItem(s.EventType.ToString());
                    item.SubItems.Add(s.DeliveryPreference.Address);
                    SubscriptionsLV.Items.Add(item);
                }

                if (SubscriptionsLV.Items.Count > 0)
                {
                    TFSUpdateB.Text = "Update Subscriptions";
                    UnsubscribeB.Enabled = true;
                }
                else
                {
                    TFSUpdateB.Text = "Subscribe";
                    UnsubscribeB.Enabled = false;
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
                lblCurrentSubscriptions.Enabled = false;
                lblListenerUrl.Enabled = false;
            }
        }

        public static void TFSUnsubscribe()
        {
            if(TfsServer == null)
            {
                TfsServer = Utils.ConnectToTFS();
            }

            // Get Eventing Service
            var eventService = (IEventService) TfsServer.GetService(typeof(IEventService));

            const string tag = "VersionOneTFSServer";

            // Unsubscribe to all events
            foreach (var s in eventService.GetEventSubscriptions(TfsServer.AuthorizedIdentity.Descriptor, tag))
            {
                eventService.UnsubscribeEvent(s.ID);
            }
        }

        public static void SetNetVersion(DirectoryEntry e, Version v)
        {
            var version = "Framework\\v" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build+"\\";

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
            
            if(changed)
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
        /// <param name="windowsIdentityName"></param>
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

    }
}