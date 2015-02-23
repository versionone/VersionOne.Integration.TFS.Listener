namespace VersionOne.Integration.Tfs.Listener.Config
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpVersionOne = new System.Windows.Forms.TabPage();
            this.grpProxySettings = new System.Windows.Forms.GroupBox();
            this.txtProxyDomain = new System.Windows.Forms.TextBox();
            this.lblProxyDomain = new System.Windows.Forms.Label();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblProxyPassword = new System.Windows.Forms.Label();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.lblProxyUsername = new System.Windows.Forms.Label();
            this.txtProxyUrl = new System.Windows.Forms.TextBox();
            this.lblProxyUrl = new System.Windows.Forms.Label();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.UseIntegratedAuthenticationCB = new System.Windows.Forms.CheckBox();
            this.btnTestV1Connection = new System.Windows.Forms.Button();
            this.V1PasswordTB = new System.Windows.Forms.MaskedTextBox();
            this.lblVersionOnePassword = new System.Windows.Forms.Label();
            this.lblVersionOneUsername = new System.Windows.Forms.Label();
            this.V1UsernameTB = new System.Windows.Forms.TextBox();
            this.lblVersionOneUrl = new System.Windows.Forms.Label();
            this.V1URLTB = new System.Windows.Forms.TextBox();
            this.tpTfsServer = new System.Windows.Forms.TabPage();
            this.TFSTestEventsB = new System.Windows.Forms.Button();
            this.SubscriptionsLV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnsubscribeB = new System.Windows.Forms.Button();
            this.lblListenerUrl = new System.Windows.Forms.Label();
            this.TFSUpdateB = new System.Windows.Forms.Button();
            this.ListenerURLTB = new System.Windows.Forms.TextBox();
            this.TFSStatusLabel = new System.Windows.Forms.Label();
            this.lblCurrentSubscriptions = new System.Windows.Forms.Label();
            this.TFSConnectB = new System.Windows.Forms.Button();
            this.TFSPasswordTB = new System.Windows.Forms.MaskedTextBox();
            this.lblTfsPassword = new System.Windows.Forms.Label();
            this.lblTfsUsername = new System.Windows.Forms.Label();
            this.TFSUsernameTB = new System.Windows.Forms.TextBox();
            this.lblTfsServerUrl = new System.Windows.Forms.Label();
            this.TFSURLTB = new System.Windows.Forms.TextBox();
            this.tpAdvanced = new System.Windows.Forms.TabPage();
            this.txtDebugDescription = new System.Windows.Forms.TextBox();
            this.chkDebugMode = new System.Windows.Forms.CheckBox();
            this.RegExTB = new System.Windows.Forms.TextBox();
            this.lblRegex = new System.Windows.Forms.Label();
            this.txtMatchesDescription = new System.Windows.Forms.TextBox();
            this.btnSaveAllSettings = new System.Windows.Forms.Button();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.llClear = new System.Windows.Forms.LinkLabel();
            this.tbBaseUrl = new System.Windows.Forms.TextBox();
            this.lblTFSListenerUrl = new System.Windows.Forms.Label();
            this.btnSetBaseListenerUrl = new System.Windows.Forms.Button();
            this.tcSettings.SuspendLayout();
            this.tpVersionOne.SuspendLayout();
            this.grpProxySettings.SuspendLayout();
            this.tpTfsServer.SuspendLayout();
            this.tpAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpVersionOne);
            this.tcSettings.Controls.Add(this.tpTfsServer);
            this.tcSettings.Controls.Add(this.tpAdvanced);
            this.tcSettings.Location = new System.Drawing.Point(10, 57);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(441, 439);
            this.tcSettings.TabIndex = 0;
            // 
            // tpVersionOne
            // 
            this.tpVersionOne.Controls.Add(this.grpProxySettings);
            this.tpVersionOne.Controls.Add(this.UseIntegratedAuthenticationCB);
            this.tpVersionOne.Controls.Add(this.btnTestV1Connection);
            this.tpVersionOne.Controls.Add(this.V1PasswordTB);
            this.tpVersionOne.Controls.Add(this.lblVersionOnePassword);
            this.tpVersionOne.Controls.Add(this.lblVersionOneUsername);
            this.tpVersionOne.Controls.Add(this.V1UsernameTB);
            this.tpVersionOne.Controls.Add(this.lblVersionOneUrl);
            this.tpVersionOne.Controls.Add(this.V1URLTB);
            this.tpVersionOne.Location = new System.Drawing.Point(4, 22);
            this.tpVersionOne.Name = "tpVersionOne";
            this.tpVersionOne.Padding = new System.Windows.Forms.Padding(3);
            this.tpVersionOne.Size = new System.Drawing.Size(433, 413);
            this.tpVersionOne.TabIndex = 0;
            this.tpVersionOne.Text = "VersionOne Server";
            this.tpVersionOne.UseVisualStyleBackColor = true;
            // 
            // grpProxySettings
            // 
            this.grpProxySettings.Controls.Add(this.txtProxyDomain);
            this.grpProxySettings.Controls.Add(this.lblProxyDomain);
            this.grpProxySettings.Controls.Add(this.txtProxyPassword);
            this.grpProxySettings.Controls.Add(this.lblProxyPassword);
            this.grpProxySettings.Controls.Add(this.txtProxyUsername);
            this.grpProxySettings.Controls.Add(this.lblProxyUsername);
            this.grpProxySettings.Controls.Add(this.txtProxyUrl);
            this.grpProxySettings.Controls.Add(this.lblProxyUrl);
            this.grpProxySettings.Controls.Add(this.chkUseProxy);
            this.grpProxySettings.Location = new System.Drawing.Point(6, 143);
            this.grpProxySettings.Name = "grpProxySettings";
            this.grpProxySettings.Size = new System.Drawing.Size(433, 184);
            this.grpProxySettings.TabIndex = 7;
            this.grpProxySettings.TabStop = false;
            this.grpProxySettings.Text = "Proxy Server Settings";
            // 
            // txtProxyDomain
            // 
            this.txtProxyDomain.Location = new System.Drawing.Point(124, 149);
            this.txtProxyDomain.Name = "txtProxyDomain";
            this.txtProxyDomain.Size = new System.Drawing.Size(303, 20);
            this.txtProxyDomain.TabIndex = 8;
            // 
            // lblProxyDomain
            // 
            this.lblProxyDomain.AutoSize = true;
            this.lblProxyDomain.Location = new System.Drawing.Point(14, 152);
            this.lblProxyDomain.Name = "lblProxyDomain";
            this.lblProxyDomain.Size = new System.Drawing.Size(43, 13);
            this.lblProxyDomain.TabIndex = 7;
            this.lblProxyDomain.Text = "Domain";
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(124, 117);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(303, 20);
            this.txtProxyPassword.TabIndex = 6;
            this.txtProxyPassword.UseSystemPasswordChar = true;
            // 
            // lblProxyPassword
            // 
            this.lblProxyPassword.AutoSize = true;
            this.lblProxyPassword.Location = new System.Drawing.Point(14, 120);
            this.lblProxyPassword.Name = "lblProxyPassword";
            this.lblProxyPassword.Size = new System.Drawing.Size(53, 13);
            this.lblProxyPassword.TabIndex = 5;
            this.lblProxyPassword.Text = "Password";
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Location = new System.Drawing.Point(124, 85);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(303, 20);
            this.txtProxyUsername.TabIndex = 4;
            // 
            // lblProxyUsername
            // 
            this.lblProxyUsername.AutoSize = true;
            this.lblProxyUsername.Location = new System.Drawing.Point(14, 88);
            this.lblProxyUsername.Name = "lblProxyUsername";
            this.lblProxyUsername.Size = new System.Drawing.Size(55, 13);
            this.lblProxyUsername.TabIndex = 3;
            this.lblProxyUsername.Text = "Username";
            // 
            // txtProxyUrl
            // 
            this.txtProxyUrl.Location = new System.Drawing.Point(124, 53);
            this.txtProxyUrl.Name = "txtProxyUrl";
            this.txtProxyUrl.Size = new System.Drawing.Size(303, 20);
            this.txtProxyUrl.TabIndex = 2;
            // 
            // lblProxyUrl
            // 
            this.lblProxyUrl.AutoSize = true;
            this.lblProxyUrl.Location = new System.Drawing.Point(14, 56);
            this.lblProxyUrl.Name = "lblProxyUrl";
            this.lblProxyUrl.Size = new System.Drawing.Size(92, 13);
            this.lblProxyUrl.TabIndex = 1;
            this.lblProxyUrl.Text = "Proxy Server URL";
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(17, 23);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(216, 17);
            this.chkUseProxy.TabIndex = 0;
            this.chkUseProxy.Text = "Use Proxy Server to Access VersionOne";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
            // 
            // UseIntegratedAuthenticationCB
            // 
            this.UseIntegratedAuthenticationCB.AutoSize = true;
            this.UseIntegratedAuthenticationCB.Location = new System.Drawing.Point(8, 115);
            this.UseIntegratedAuthenticationCB.Name = "UseIntegratedAuthenticationCB";
            this.UseIntegratedAuthenticationCB.Size = new System.Drawing.Size(214, 17);
            this.UseIntegratedAuthenticationCB.TabIndex = 6;
            this.UseIntegratedAuthenticationCB.Text = "Use Windows Integrated Authentication";
            this.UseIntegratedAuthenticationCB.UseVisualStyleBackColor = true;
            // 
            // btnTestV1Connection
            // 
            this.btnTestV1Connection.Location = new System.Drawing.Point(6, 343);
            this.btnTestV1Connection.Name = "btnTestV1Connection";
            this.btnTestV1Connection.Size = new System.Drawing.Size(120, 23);
            this.btnTestV1Connection.TabIndex = 8;
            this.btnTestV1Connection.Text = "Test Connection";
            this.btnTestV1Connection.UseVisualStyleBackColor = true;
            // 
            // V1PasswordTB
            // 
            this.V1PasswordTB.Location = new System.Drawing.Point(131, 75);
            this.V1PasswordTB.Name = "V1PasswordTB";
            this.V1PasswordTB.Size = new System.Drawing.Size(302, 20);
            this.V1PasswordTB.TabIndex = 5;
            this.V1PasswordTB.UseSystemPasswordChar = true;
            // 
            // lblVersionOnePassword
            // 
            this.lblVersionOnePassword.AutoSize = true;
            this.lblVersionOnePassword.Location = new System.Drawing.Point(8, 78);
            this.lblVersionOnePassword.Name = "lblVersionOnePassword";
            this.lblVersionOnePassword.Size = new System.Drawing.Size(111, 13);
            this.lblVersionOnePassword.TabIndex = 4;
            this.lblVersionOnePassword.Text = "VersionOne Password";
            // 
            // lblVersionOneUsername
            // 
            this.lblVersionOneUsername.AutoSize = true;
            this.lblVersionOneUsername.Location = new System.Drawing.Point(8, 46);
            this.lblVersionOneUsername.Name = "lblVersionOneUsername";
            this.lblVersionOneUsername.Size = new System.Drawing.Size(113, 13);
            this.lblVersionOneUsername.TabIndex = 2;
            this.lblVersionOneUsername.Text = "VersionOne Username";
            // 
            // V1UsernameTB
            // 
            this.V1UsernameTB.Location = new System.Drawing.Point(131, 43);
            this.V1UsernameTB.Name = "V1UsernameTB";
            this.V1UsernameTB.Size = new System.Drawing.Size(302, 20);
            this.V1UsernameTB.TabIndex = 3;
            // 
            // lblVersionOneUrl
            // 
            this.lblVersionOneUrl.AutoSize = true;
            this.lblVersionOneUrl.Location = new System.Drawing.Point(7, 14);
            this.lblVersionOneUrl.Name = "lblVersionOneUrl";
            this.lblVersionOneUrl.Size = new System.Drawing.Size(121, 13);
            this.lblVersionOneUrl.TabIndex = 0;
            this.lblVersionOneUrl.Text = "VersionOne Server URL";
            // 
            // V1URLTB
            // 
            this.V1URLTB.Location = new System.Drawing.Point(131, 11);
            this.V1URLTB.Name = "V1URLTB";
            this.V1URLTB.Size = new System.Drawing.Size(302, 20);
            this.V1URLTB.TabIndex = 1;
            // 
            // tpTfsServer
            // 
            this.tpTfsServer.Controls.Add(this.TFSTestEventsB);
            this.tpTfsServer.Controls.Add(this.SubscriptionsLV);
            this.tpTfsServer.Controls.Add(this.UnsubscribeB);
            this.tpTfsServer.Controls.Add(this.lblListenerUrl);
            this.tpTfsServer.Controls.Add(this.TFSUpdateB);
            this.tpTfsServer.Controls.Add(this.ListenerURLTB);
            this.tpTfsServer.Controls.Add(this.TFSStatusLabel);
            this.tpTfsServer.Controls.Add(this.lblCurrentSubscriptions);
            this.tpTfsServer.Controls.Add(this.TFSConnectB);
            this.tpTfsServer.Controls.Add(this.TFSPasswordTB);
            this.tpTfsServer.Controls.Add(this.lblTfsPassword);
            this.tpTfsServer.Controls.Add(this.lblTfsUsername);
            this.tpTfsServer.Controls.Add(this.TFSUsernameTB);
            this.tpTfsServer.Controls.Add(this.lblTfsServerUrl);
            this.tpTfsServer.Controls.Add(this.TFSURLTB);
            this.tpTfsServer.Location = new System.Drawing.Point(4, 22);
            this.tpTfsServer.Name = "tpTfsServer";
            this.tpTfsServer.Padding = new System.Windows.Forms.Padding(3);
            this.tpTfsServer.Size = new System.Drawing.Size(433, 413);
            this.tpTfsServer.TabIndex = 1;
            this.tpTfsServer.Text = "TFS Server";
            this.tpTfsServer.UseVisualStyleBackColor = true;
            // 
            // TFSTestEventsB
            // 
            this.TFSTestEventsB.Location = new System.Drawing.Point(287, 378);
            this.TFSTestEventsB.Name = "TFSTestEventsB";
            this.TFSTestEventsB.Size = new System.Drawing.Size(135, 23);
            this.TFSTestEventsB.TabIndex = 30;
            this.TFSTestEventsB.Text = "Test Events";
            this.TFSTestEventsB.UseVisualStyleBackColor = true;
            // 
            // SubscriptionsLV
            // 
            this.SubscriptionsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.SubscriptionsLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SubscriptionsLV.Location = new System.Drawing.Point(7, 250);
            this.SubscriptionsLV.Name = "SubscriptionsLV";
            this.SubscriptionsLV.Size = new System.Drawing.Size(435, 80);
            this.SubscriptionsLV.TabIndex = 29;
            this.SubscriptionsLV.UseCompatibleStateImageBehavior = false;
            this.SubscriptionsLV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Event";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subscription URL";
            this.columnHeader2.Width = 600;
            // 
            // UnsubscribeB
            // 
            this.UnsubscribeB.Location = new System.Drawing.Point(147, 378);
            this.UnsubscribeB.Name = "UnsubscribeB";
            this.UnsubscribeB.Size = new System.Drawing.Size(135, 23);
            this.UnsubscribeB.TabIndex = 28;
            this.UnsubscribeB.Text = "Unsubscribe";
            this.UnsubscribeB.UseVisualStyleBackColor = true;
            // 
            // lblListenerUrl
            // 
            this.lblListenerUrl.AutoSize = true;
            this.lblListenerUrl.Location = new System.Drawing.Point(6, 333);
            this.lblListenerUrl.Name = "lblListenerUrl";
            this.lblListenerUrl.Size = new System.Drawing.Size(92, 13);
            this.lblListenerUrl.TabIndex = 26;
            this.lblListenerUrl.Text = "TFS Listener URL";
            // 
            // TFSUpdateB
            // 
            this.TFSUpdateB.Location = new System.Drawing.Point(7, 378);
            this.TFSUpdateB.Name = "TFSUpdateB";
            this.TFSUpdateB.Size = new System.Drawing.Size(135, 23);
            this.TFSUpdateB.TabIndex = 25;
            this.TFSUpdateB.Text = "Subscribe";
            this.TFSUpdateB.UseVisualStyleBackColor = true;
            // 
            // ListenerURLTB
            // 
            this.ListenerURLTB.Enabled = false;
            this.ListenerURLTB.Location = new System.Drawing.Point(7, 349);
            this.ListenerURLTB.Name = "ListenerURLTB";
            this.ListenerURLTB.Size = new System.Drawing.Size(435, 20);
            this.ListenerURLTB.TabIndex = 24;
            // 
            // TFSStatusLabel
            // 
            this.TFSStatusLabel.AutoSize = true;
            this.TFSStatusLabel.Location = new System.Drawing.Point(13, 213);
            this.TFSStatusLabel.Name = "TFSStatusLabel";
            this.TFSStatusLabel.Size = new System.Drawing.Size(78, 13);
            this.TFSStatusLabel.TabIndex = 21;
            this.TFSStatusLabel.Text = "Not connected";
            // 
            // lblCurrentSubscriptions
            // 
            this.lblCurrentSubscriptions.AutoSize = true;
            this.lblCurrentSubscriptions.Location = new System.Drawing.Point(6, 234);
            this.lblCurrentSubscriptions.Name = "lblCurrentSubscriptions";
            this.lblCurrentSubscriptions.Size = new System.Drawing.Size(107, 13);
            this.lblCurrentSubscriptions.TabIndex = 20;
            this.lblCurrentSubscriptions.Text = "Current Subscriptions";
            // 
            // TFSConnectB
            // 
            this.TFSConnectB.Location = new System.Drawing.Point(7, 181);
            this.TFSConnectB.Name = "TFSConnectB";
            this.TFSConnectB.Size = new System.Drawing.Size(75, 23);
            this.TFSConnectB.TabIndex = 17;
            this.TFSConnectB.Text = "Connect";
            this.TFSConnectB.UseVisualStyleBackColor = true;
            // 
            // TFSPasswordTB
            // 
            this.TFSPasswordTB.Location = new System.Drawing.Point(7, 135);
            this.TFSPasswordTB.Name = "TFSPasswordTB";
            this.TFSPasswordTB.Size = new System.Drawing.Size(196, 20);
            this.TFSPasswordTB.TabIndex = 16;
            this.TFSPasswordTB.UseSystemPasswordChar = true;
            // 
            // lblTfsPassword
            // 
            this.lblTfsPassword.AutoSize = true;
            this.lblTfsPassword.Location = new System.Drawing.Point(7, 119);
            this.lblTfsPassword.Name = "lblTfsPassword";
            this.lblTfsPassword.Size = new System.Drawing.Size(76, 13);
            this.lblTfsPassword.TabIndex = 15;
            this.lblTfsPassword.Text = "TFS Password";
            // 
            // lblTfsUsername
            // 
            this.lblTfsUsername.AutoSize = true;
            this.lblTfsUsername.Location = new System.Drawing.Point(7, 69);
            this.lblTfsUsername.Name = "lblTfsUsername";
            this.lblTfsUsername.Size = new System.Drawing.Size(78, 13);
            this.lblTfsUsername.TabIndex = 14;
            this.lblTfsUsername.Text = "TFS Username";
            // 
            // TFSUsernameTB
            // 
            this.TFSUsernameTB.Location = new System.Drawing.Point(7, 85);
            this.TFSUsernameTB.Name = "TFSUsernameTB";
            this.TFSUsernameTB.Size = new System.Drawing.Size(196, 20);
            this.TFSUsernameTB.TabIndex = 13;
            // 
            // lblTfsServerUrl
            // 
            this.lblTfsServerUrl.AutoSize = true;
            this.lblTfsServerUrl.Location = new System.Drawing.Point(7, 14);
            this.lblTfsServerUrl.Name = "lblTfsServerUrl";
            this.lblTfsServerUrl.Size = new System.Drawing.Size(86, 13);
            this.lblTfsServerUrl.TabIndex = 12;
            this.lblTfsServerUrl.Text = "TFS Server URL";
            // 
            // TFSURLTB
            // 
            this.TFSURLTB.Location = new System.Drawing.Point(7, 30);
            this.TFSURLTB.Name = "TFSURLTB";
            this.TFSURLTB.Size = new System.Drawing.Size(435, 20);
            this.TFSURLTB.TabIndex = 11;
            // 
            // tpAdvanced
            // 
            this.tpAdvanced.AutoScroll = true;
            this.tpAdvanced.Controls.Add(this.txtDebugDescription);
            this.tpAdvanced.Controls.Add(this.chkDebugMode);
            this.tpAdvanced.Controls.Add(this.RegExTB);
            this.tpAdvanced.Controls.Add(this.lblRegex);
            this.tpAdvanced.Controls.Add(this.txtMatchesDescription);
            this.tpAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tpAdvanced.Name = "tpAdvanced";
            this.tpAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdvanced.Size = new System.Drawing.Size(433, 413);
            this.tpAdvanced.TabIndex = 2;
            this.tpAdvanced.Text = "Advanced";
            this.tpAdvanced.UseVisualStyleBackColor = true;
            // 
            // txtDebugDescription
            // 
            this.txtDebugDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDebugDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDebugDescription.Location = new System.Drawing.Point(9, 140);
            this.txtDebugDescription.Multiline = true;
            this.txtDebugDescription.Name = "txtDebugDescription";
            this.txtDebugDescription.ReadOnly = true;
            this.txtDebugDescription.Size = new System.Drawing.Size(421, 45);
            this.txtDebugDescription.TabIndex = 5;
            // 
            // chkDebugMode
            // 
            this.chkDebugMode.AutoSize = true;
            this.chkDebugMode.Location = new System.Drawing.Point(9, 117);
            this.chkDebugMode.Name = "chkDebugMode";
            this.chkDebugMode.Size = new System.Drawing.Size(88, 17);
            this.chkDebugMode.TabIndex = 4;
            this.chkDebugMode.Text = "Debug Mode";
            this.chkDebugMode.UseVisualStyleBackColor = true;
            // 
            // RegExTB
            // 
            this.RegExTB.Location = new System.Drawing.Point(9, 23);
            this.RegExTB.Name = "RegExTB";
            this.RegExTB.Size = new System.Drawing.Size(421, 20);
            this.RegExTB.TabIndex = 2;
            this.RegExTB.Text = "[A-Z]{1,2}-[0-9]+";
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(9, 7);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(204, 13);
            this.lblRegex.TabIndex = 1;
            this.lblRegex.Text = "VersionOne Workitem Regular Expression";
            // 
            // txtMatchesDescription
            // 
            this.txtMatchesDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatchesDescription.Location = new System.Drawing.Point(9, 49);
            this.txtMatchesDescription.Multiline = true;
            this.txtMatchesDescription.Name = "txtMatchesDescription";
            this.txtMatchesDescription.ReadOnly = true;
            this.txtMatchesDescription.Size = new System.Drawing.Size(421, 47);
            this.txtMatchesDescription.TabIndex = 0;
            this.txtMatchesDescription.Text = resources.GetString("txtMatchesDescription.Text");
            // 
            // btnSaveAllSettings
            // 
            this.btnSaveAllSettings.Location = new System.Drawing.Point(153, 502);
            this.btnSaveAllSettings.Name = "btnSaveAllSettings";
            this.btnSaveAllSettings.Size = new System.Drawing.Size(145, 28);
            this.btnSaveAllSettings.TabIndex = 32;
            this.btnSaveAllSettings.Text = "Save All Settings";
            this.btnSaveAllSettings.UseVisualStyleBackColor = true;
            // 
            // tbResults
            // 
            this.tbResults.BackColor = System.Drawing.Color.Black;
            this.tbResults.ForeColor = System.Drawing.Color.White;
            this.tbResults.Location = new System.Drawing.Point(10, 533);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResults.Size = new System.Drawing.Size(441, 100);
            this.tbResults.TabIndex = 10;
            // 
            // llClear
            // 
            this.llClear.AutoSize = true;
            this.llClear.Location = new System.Drawing.Point(420, 515);
            this.llClear.Name = "llClear";
            this.llClear.Size = new System.Drawing.Size(31, 13);
            this.llClear.TabIndex = 34;
            this.llClear.TabStop = true;
            this.llClear.Text = "Clear";
            this.llClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llClear_LinkClicked);
            // 
            // tbBaseUrl
            // 
            this.tbBaseUrl.Location = new System.Drawing.Point(121, 26);
            this.tbBaseUrl.Name = "tbBaseUrl";
            this.tbBaseUrl.Size = new System.Drawing.Size(243, 20);
            this.tbBaseUrl.TabIndex = 13;
            // 
            // lblTFSListenerUrl
            // 
            this.lblTFSListenerUrl.AutoSize = true;
            this.lblTFSListenerUrl.Location = new System.Drawing.Point(7, 29);
            this.lblTFSListenerUrl.Name = "lblTFSListenerUrl";
            this.lblTFSListenerUrl.Size = new System.Drawing.Size(110, 13);
            this.lblTFSListenerUrl.TabIndex = 14;
            this.lblTFSListenerUrl.Text = "TFS Base Listener Url";
            // 
            // btnSetBaseListenerUrl
            // 
            this.btnSetBaseListenerUrl.Location = new System.Drawing.Point(369, 26);
            this.btnSetBaseListenerUrl.Name = "btnSetBaseListenerUrl";
            this.btnSetBaseListenerUrl.Size = new System.Drawing.Size(75, 20);
            this.btnSetBaseListenerUrl.TabIndex = 15;
            this.btnSetBaseListenerUrl.Text = "Refresh";
            this.btnSetBaseListenerUrl.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 636);
            this.Controls.Add(this.btnSetBaseListenerUrl);
            this.Controls.Add(this.lblTFSListenerUrl);
            this.Controls.Add(this.tbBaseUrl);
            this.Controls.Add(this.llClear);
            this.Controls.Add(this.btnSaveAllSettings);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.tcSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "VersionOne TFS Listener Configuration";
            this.tcSettings.ResumeLayout(false);
            this.tpVersionOne.ResumeLayout(false);
            this.tpVersionOne.PerformLayout();
            this.grpProxySettings.ResumeLayout(false);
            this.grpProxySettings.PerformLayout();
            this.tpTfsServer.ResumeLayout(false);
            this.tpTfsServer.PerformLayout();
            this.tpAdvanced.ResumeLayout(false);
            this.tpAdvanced.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tpVersionOne;
        private System.Windows.Forms.TabPage tpTfsServer;
        private System.Windows.Forms.Button btnTestV1Connection;
        private System.Windows.Forms.MaskedTextBox V1PasswordTB;
        private System.Windows.Forms.Label lblVersionOnePassword;
        private System.Windows.Forms.Label lblVersionOneUsername;
        private System.Windows.Forms.TextBox V1UsernameTB;
        private System.Windows.Forms.Label lblVersionOneUrl;
        private System.Windows.Forms.TextBox V1URLTB;
        private System.Windows.Forms.Label lblCurrentSubscriptions;
        private System.Windows.Forms.Button TFSConnectB;
        private System.Windows.Forms.MaskedTextBox TFSPasswordTB;
        private System.Windows.Forms.Label lblTfsPassword;
        private System.Windows.Forms.Label lblTfsUsername;
        private System.Windows.Forms.TextBox TFSUsernameTB;
        private System.Windows.Forms.Label lblTfsServerUrl;
        private System.Windows.Forms.TextBox TFSURLTB;
        private System.Windows.Forms.Label TFSStatusLabel;
        private System.Windows.Forms.CheckBox UseIntegratedAuthenticationCB;
        private System.Windows.Forms.TextBox ListenerURLTB;
        private System.Windows.Forms.Label lblListenerUrl;
        private System.Windows.Forms.Button TFSUpdateB;
        private System.Windows.Forms.Button UnsubscribeB;
        private System.Windows.Forms.ListView SubscriptionsLV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tpAdvanced;
        private System.Windows.Forms.TextBox RegExTB;
        private System.Windows.Forms.Label lblRegex;
		private System.Windows.Forms.TextBox txtMatchesDescription;
        private System.Windows.Forms.CheckBox chkDebugMode;
        private System.Windows.Forms.GroupBox grpProxySettings;
        private System.Windows.Forms.TextBox txtProxyDomain;
        private System.Windows.Forms.Label lblProxyDomain;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblProxyPassword;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.Label lblProxyUsername;
        private System.Windows.Forms.TextBox txtProxyUrl;
        private System.Windows.Forms.Label lblProxyUrl;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.Button btnSaveAllSettings;
        private System.Windows.Forms.TextBox txtDebugDescription;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.LinkLabel llClear;
        private System.Windows.Forms.TextBox tbBaseUrl;
        private System.Windows.Forms.Label lblTFSListenerUrl;
        private System.Windows.Forms.Button btnSetBaseListenerUrl;
        private System.Windows.Forms.Button TFSTestEventsB;
    }
}

