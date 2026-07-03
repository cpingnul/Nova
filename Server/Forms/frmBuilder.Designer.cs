
namespace Nova.Forms
{
    partial class frmBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuilder));
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.groupConnection = new System.Windows.Forms.GroupBox();
            this.lblMS = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkIconChange = new System.Windows.Forms.CheckBox();
            this.chkElevation = new System.Windows.Forms.CheckBox();
            this.picUAC1 = new System.Windows.Forms.PictureBox();
            this.rbSystem = new System.Windows.Forms.RadioButton();
            this.lblRegistryKeyName = new System.Windows.Forms.Label();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.btnMutex = new System.Windows.Forms.Button();
            this.lblExamplePath = new System.Windows.Forms.Label();
            this.txtExamplePath = new System.Windows.Forms.TextBox();
            this.lblInstallsub = new System.Windows.Forms.Label();
            this.lblInstallpath = new System.Windows.Forms.Label();
            this.rbAppdata = new System.Windows.Forms.RadioButton();
            this.txtMutex = new System.Windows.Forms.TextBox();
            this.lblMutex = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.txtInstallname = new System.Windows.Forms.TextBox();
            this.lblInstallname = new System.Windows.Forms.Label();
            this.chkInstall = new System.Windows.Forms.CheckBox();
            this.groupInstall = new System.Windows.Forms.GroupBox();
            this.picUAC2 = new System.Windows.Forms.PictureBox();
            this.rbProgramFiles = new System.Windows.Forms.RadioButton();
            this.txtRegistryKeyName = new System.Windows.Forms.TextBox();
            this.txtInstallsub = new System.Windows.Forms.TextBox();
            this.chkChangeAsmInfo = new System.Windows.Forms.CheckBox();
            this.txtFileVersion = new System.Windows.Forms.TextBox();
            this.lblFileVersion = new System.Windows.Forms.Label();
            this.txtProductVersion = new System.Windows.Forms.TextBox();
            this.lblProductVersion = new System.Windows.Forms.Label();
            this.txtOriginalFilename = new System.Windows.Forms.TextBox();
            this.lblOriginalFilename = new System.Windows.Forms.Label();
            this.txtTrademarks = new System.Windows.Forms.TextBox();
            this.lblTrademarks = new System.Windows.Forms.Label();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.groupAsmInfo = new System.Windows.Forms.GroupBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.groupConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUAC1)).BeginInit();
            this.groupInstall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUAC2)).BeginInit();
            this.groupAsmInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(271, 89);
            this.txtPort.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(272, 39);
            this.txtPort.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(31, 96);
            this.lblPort.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(62, 32);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(271, 35);
            this.txtHost.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(272, 39);
            this.txtHost.TabIndex = 1;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(31, 40);
            this.lblHost.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(157, 32);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "IP/Hostname:";
            // 
            // groupConnection
            // 
            this.groupConnection.Controls.Add(this.lblMS);
            this.groupConnection.Controls.Add(this.txtDelay);
            this.groupConnection.Controls.Add(this.lblDelay);
            this.groupConnection.Controls.Add(this.chkShowPass);
            this.groupConnection.Controls.Add(this.txtPassword);
            this.groupConnection.Controls.Add(this.lblPassword);
            this.groupConnection.Controls.Add(this.txtPort);
            this.groupConnection.Controls.Add(this.lblPort);
            this.groupConnection.Controls.Add(this.txtHost);
            this.groupConnection.Controls.Add(this.lblHost);
            this.groupConnection.Location = new System.Drawing.Point(15, 21);
            this.groupConnection.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.groupConnection.Name = "groupConnection";
            this.groupConnection.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.groupConnection.Size = new System.Drawing.Size(578, 324);
            this.groupConnection.TabIndex = 1;
            this.groupConnection.TabStop = false;
            this.groupConnection.Text = "Connection";
            // 
            // lblMS
            // 
            this.lblMS.AutoSize = true;
            this.lblMS.Location = new System.Drawing.Point(496, 268);
            this.lblMS.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMS.Name = "lblMS";
            this.lblMS.Size = new System.Drawing.Size(46, 32);
            this.lblMS.TabIndex = 9;
            this.lblMS.Text = "ms";
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(271, 261);
            this.txtDelay.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtDelay.MaxLength = 6;
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(216, 39);
            this.txtDelay.TabIndex = 8;
            this.txtDelay.Text = "5000";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(31, 267);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(198, 32);
            this.lblDelay.TabIndex = 7;
            this.lblDelay.Text = "Reconnect Delay:";
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(271, 212);
            this.chkShowPass.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(203, 36);
            this.chkShowPass.TabIndex = 6;
            this.chkShowPass.Text = "Show Password";
            this.chkShowPass.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(271, 151);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(272, 39);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(31, 157);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(117, 32);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // chkIconChange
            // 
            this.chkIconChange.AutoSize = true;
            this.chkIconChange.Location = new System.Drawing.Point(271, 553);
            this.chkIconChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIconChange.Name = "chkIconChange";
            this.chkIconChange.Size = new System.Drawing.Size(175, 36);
            this.chkIconChange.TabIndex = 20;
            this.chkIconChange.Text = "Change Icon";
            this.chkIconChange.UseVisualStyleBackColor = true;
            // 
            // chkElevation
            // 
            this.chkElevation.AutoSize = true;
            this.chkElevation.Location = new System.Drawing.Point(271, 518);
            this.chkElevation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkElevation.Name = "chkElevation";
            this.chkElevation.Size = new System.Drawing.Size(293, 36);
            this.chkElevation.TabIndex = 19;
            this.chkElevation.Text = "Enable Admin Elevation";
            this.chkElevation.UseVisualStyleBackColor = true;
            // 
            // picUAC1
            // 
            this.picUAC1.Location = new System.Drawing.Point(488, 209);
            this.picUAC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picUAC1.Name = "picUAC1";
            this.picUAC1.Size = new System.Drawing.Size(16, 20);
            this.picUAC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUAC1.TabIndex = 31;
            this.picUAC1.TabStop = false;
            // 
            // rbSystem
            // 
            this.rbSystem.AutoSize = true;
            this.rbSystem.Location = new System.Drawing.Point(271, 265);
            this.rbSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSystem.Name = "rbSystem";
            this.rbSystem.Size = new System.Drawing.Size(116, 36);
            this.rbSystem.TabIndex = 10;
            this.rbSystem.TabStop = true;
            this.rbSystem.Text = "System";
            this.rbSystem.UseVisualStyleBackColor = true;
            // 
            // lblRegistryKeyName
            // 
            this.lblRegistryKeyName.AutoSize = true;
            this.lblRegistryKeyName.Location = new System.Drawing.Point(28, 467);
            this.lblRegistryKeyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistryKeyName.Name = "lblRegistryKeyName";
            this.lblRegistryKeyName.Size = new System.Drawing.Size(221, 32);
            this.lblRegistryKeyName.TabIndex = 17;
            this.lblRegistryKeyName.Text = "Registry Key Name:";
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(271, 436);
            this.chkStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(196, 36);
            this.chkStartup.TabIndex = 16;
            this.chkStartup.Text = "Add to Startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            // 
            // chkHide
            // 
            this.chkHide.AutoSize = true;
            this.chkHide.Location = new System.Drawing.Point(271, 401);
            this.chkHide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(135, 36);
            this.chkHide.TabIndex = 15;
            this.chkHide.Text = "Hide File";
            this.chkHide.UseVisualStyleBackColor = true;
            // 
            // btnMutex
            // 
            this.btnMutex.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMutex.Location = new System.Drawing.Point(443, 85);
            this.btnMutex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMutex.Name = "btnMutex";
            this.btnMutex.Size = new System.Drawing.Size(100, 57);
            this.btnMutex.TabIndex = 3;
            this.btnMutex.Text = "New Mutex";
            this.btnMutex.UseVisualStyleBackColor = true;
            // 
            // lblExamplePath
            // 
            this.lblExamplePath.AutoSize = true;
            this.lblExamplePath.Location = new System.Drawing.Point(28, 350);
            this.lblExamplePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExamplePath.Name = "lblExamplePath";
            this.lblExamplePath.Size = new System.Drawing.Size(162, 32);
            this.lblExamplePath.TabIndex = 13;
            this.lblExamplePath.Text = "Example Path:";
            // 
            // txtExamplePath
            // 
            this.txtExamplePath.Location = new System.Drawing.Point(271, 359);
            this.txtExamplePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExamplePath.Name = "txtExamplePath";
            this.txtExamplePath.ReadOnly = true;
            this.txtExamplePath.Size = new System.Drawing.Size(272, 39);
            this.txtExamplePath.TabIndex = 14;
            // 
            // lblInstallsub
            // 
            this.lblInstallsub.AutoSize = true;
            this.lblInstallsub.Location = new System.Drawing.Point(28, 296);
            this.lblInstallsub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstallsub.Name = "lblInstallsub";
            this.lblInstallsub.Size = new System.Drawing.Size(193, 32);
            this.lblInstallsub.TabIndex = 11;
            this.lblInstallsub.Text = "Install Subfolder:";
            // 
            // lblInstallpath
            // 
            this.lblInstallpath.AutoSize = true;
            this.lblInstallpath.Location = new System.Drawing.Point(28, 198);
            this.lblInstallpath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstallpath.Name = "lblInstallpath";
            this.lblInstallpath.Size = new System.Drawing.Size(135, 32);
            this.lblInstallpath.TabIndex = 7;
            this.lblInstallpath.Text = "Install Path:";
            // 
            // rbAppdata
            // 
            this.rbAppdata.AutoSize = true;
            this.rbAppdata.Checked = true;
            this.rbAppdata.Location = new System.Drawing.Point(271, 196);
            this.rbAppdata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbAppdata.Name = "rbAppdata";
            this.rbAppdata.Size = new System.Drawing.Size(216, 36);
            this.rbAppdata.TabIndex = 8;
            this.rbAppdata.TabStop = true;
            this.rbAppdata.Text = "Application Data";
            this.rbAppdata.UseVisualStyleBackColor = true;
            // 
            // txtMutex
            // 
            this.txtMutex.Location = new System.Drawing.Point(271, 41);
            this.txtMutex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMutex.MaxLength = 64;
            this.txtMutex.Name = "txtMutex";
            this.txtMutex.Size = new System.Drawing.Size(272, 39);
            this.txtMutex.TabIndex = 1;
            // 
            // lblMutex
            // 
            this.lblMutex.AutoSize = true;
            this.lblMutex.Location = new System.Drawing.Point(33, 45);
            this.lblMutex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMutex.Name = "lblMutex";
            this.lblMutex.Size = new System.Drawing.Size(88, 32);
            this.lblMutex.TabIndex = 0;
            this.lblMutex.Text = "Mutex:";
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(496, 151);
            this.lblExtension.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(57, 32);
            this.lblExtension.TabIndex = 6;
            this.lblExtension.Text = ".exe";
            // 
            // txtInstallname
            // 
            this.txtInstallname.Location = new System.Drawing.Point(271, 147);
            this.txtInstallname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInstallname.Name = "txtInstallname";
            this.txtInstallname.Size = new System.Drawing.Size(227, 39);
            this.txtInstallname.TabIndex = 5;
            // 
            // lblInstallname
            // 
            this.lblInstallname.AutoSize = true;
            this.lblInstallname.Location = new System.Drawing.Point(28, 144);
            this.lblInstallname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstallname.Name = "lblInstallname";
            this.lblInstallname.Size = new System.Drawing.Size(153, 32);
            this.lblInstallname.TabIndex = 4;
            this.lblInstallname.Text = "Install Name:";
            // 
            // chkInstall
            // 
            this.chkInstall.AutoSize = true;
            this.chkInstall.Location = new System.Drawing.Point(271, 87);
            this.chkInstall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInstall.Name = "chkInstall";
            this.chkInstall.Size = new System.Drawing.Size(172, 36);
            this.chkInstall.TabIndex = 2;
            this.chkInstall.Text = "Install Client";
            this.chkInstall.UseVisualStyleBackColor = true;
            // 
            // groupInstall
            // 
            this.groupInstall.Controls.Add(this.chkIconChange);
            this.groupInstall.Controls.Add(this.chkElevation);
            this.groupInstall.Controls.Add(this.picUAC2);
            this.groupInstall.Controls.Add(this.picUAC1);
            this.groupInstall.Controls.Add(this.rbSystem);
            this.groupInstall.Controls.Add(this.rbProgramFiles);
            this.groupInstall.Controls.Add(this.txtRegistryKeyName);
            this.groupInstall.Controls.Add(this.lblRegistryKeyName);
            this.groupInstall.Controls.Add(this.chkStartup);
            this.groupInstall.Controls.Add(this.chkHide);
            this.groupInstall.Controls.Add(this.btnMutex);
            this.groupInstall.Controls.Add(this.lblExamplePath);
            this.groupInstall.Controls.Add(this.txtExamplePath);
            this.groupInstall.Controls.Add(this.txtInstallsub);
            this.groupInstall.Controls.Add(this.lblInstallsub);
            this.groupInstall.Controls.Add(this.lblInstallpath);
            this.groupInstall.Controls.Add(this.rbAppdata);
            this.groupInstall.Controls.Add(this.txtMutex);
            this.groupInstall.Controls.Add(this.lblMutex);
            this.groupInstall.Controls.Add(this.lblExtension);
            this.groupInstall.Controls.Add(this.txtInstallname);
            this.groupInstall.Controls.Add(this.lblInstallname);
            this.groupInstall.Controls.Add(this.chkInstall);
            this.groupInstall.Location = new System.Drawing.Point(15, 358);
            this.groupInstall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupInstall.Name = "groupInstall";
            this.groupInstall.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupInstall.Size = new System.Drawing.Size(579, 601);
            this.groupInstall.TabIndex = 2;
            this.groupInstall.TabStop = false;
            this.groupInstall.Text = "Install";
            // 
            // picUAC2
            // 
            this.picUAC2.Location = new System.Drawing.Point(488, 244);
            this.picUAC2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picUAC2.Name = "picUAC2";
            this.picUAC2.Size = new System.Drawing.Size(16, 20);
            this.picUAC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUAC2.TabIndex = 32;
            this.picUAC2.TabStop = false;
            // 
            // rbProgramFiles
            // 
            this.rbProgramFiles.AutoSize = true;
            this.rbProgramFiles.Location = new System.Drawing.Point(271, 231);
            this.rbProgramFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbProgramFiles.Name = "rbProgramFiles";
            this.rbProgramFiles.Size = new System.Drawing.Size(184, 36);
            this.rbProgramFiles.TabIndex = 9;
            this.rbProgramFiles.TabStop = true;
            this.rbProgramFiles.Text = "Program Files";
            this.rbProgramFiles.UseVisualStyleBackColor = true;
            // 
            // txtRegistryKeyName
            // 
            this.txtRegistryKeyName.Location = new System.Drawing.Point(271, 475);
            this.txtRegistryKeyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRegistryKeyName.Name = "txtRegistryKeyName";
            this.txtRegistryKeyName.Size = new System.Drawing.Size(272, 39);
            this.txtRegistryKeyName.TabIndex = 18;
            // 
            // txtInstallsub
            // 
            this.txtInstallsub.Location = new System.Drawing.Point(271, 304);
            this.txtInstallsub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInstallsub.Name = "txtInstallsub";
            this.txtInstallsub.Size = new System.Drawing.Size(272, 39);
            this.txtInstallsub.TabIndex = 12;
            // 
            // chkChangeAsmInfo
            // 
            this.chkChangeAsmInfo.AutoSize = true;
            this.chkChangeAsmInfo.Location = new System.Drawing.Point(25, 46);
            this.chkChangeAsmInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkChangeAsmInfo.Name = "chkChangeAsmInfo";
            this.chkChangeAsmInfo.Size = new System.Drawing.Size(363, 36);
            this.chkChangeAsmInfo.TabIndex = 0;
            this.chkChangeAsmInfo.Text = "Change Assembly Information";
            this.chkChangeAsmInfo.UseVisualStyleBackColor = true;
            // 
            // txtFileVersion
            // 
            this.txtFileVersion.Location = new System.Drawing.Point(231, 390);
            this.txtFileVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileVersion.Name = "txtFileVersion";
            this.txtFileVersion.Size = new System.Drawing.Size(272, 39);
            this.txtFileVersion.TabIndex = 16;
            // 
            // lblFileVersion
            // 
            this.lblFileVersion.AutoSize = true;
            this.lblFileVersion.Location = new System.Drawing.Point(19, 394);
            this.lblFileVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileVersion.Name = "lblFileVersion";
            this.lblFileVersion.Size = new System.Drawing.Size(142, 32);
            this.lblFileVersion.TabIndex = 15;
            this.lblFileVersion.Text = "File Version:";
            // 
            // txtProductVersion
            // 
            this.txtProductVersion.Location = new System.Drawing.Point(231, 347);
            this.txtProductVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductVersion.Name = "txtProductVersion";
            this.txtProductVersion.Size = new System.Drawing.Size(272, 39);
            this.txtProductVersion.TabIndex = 14;
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.AutoSize = true;
            this.lblProductVersion.Location = new System.Drawing.Point(19, 352);
            this.lblProductVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(187, 32);
            this.lblProductVersion.TabIndex = 13;
            this.lblProductVersion.Text = "Product Version:";
            // 
            // txtOriginalFilename
            // 
            this.txtOriginalFilename.Location = new System.Drawing.Point(231, 304);
            this.txtOriginalFilename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOriginalFilename.Name = "txtOriginalFilename";
            this.txtOriginalFilename.Size = new System.Drawing.Size(272, 39);
            this.txtOriginalFilename.TabIndex = 12;
            // 
            // lblOriginalFilename
            // 
            this.lblOriginalFilename.AutoSize = true;
            this.lblOriginalFilename.Location = new System.Drawing.Point(19, 309);
            this.lblOriginalFilename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOriginalFilename.Name = "lblOriginalFilename";
            this.lblOriginalFilename.Size = new System.Drawing.Size(208, 32);
            this.lblOriginalFilename.TabIndex = 11;
            this.lblOriginalFilename.Text = "Original Filename:";
            // 
            // txtTrademarks
            // 
            this.txtTrademarks.Location = new System.Drawing.Point(231, 262);
            this.txtTrademarks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrademarks.Name = "txtTrademarks";
            this.txtTrademarks.Size = new System.Drawing.Size(272, 39);
            this.txtTrademarks.TabIndex = 10;
            // 
            // lblTrademarks
            // 
            this.lblTrademarks.AutoSize = true;
            this.lblTrademarks.Location = new System.Drawing.Point(19, 266);
            this.lblTrademarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrademarks.Name = "lblTrademarks";
            this.lblTrademarks.Size = new System.Drawing.Size(141, 32);
            this.lblTrademarks.TabIndex = 9;
            this.lblTrademarks.Text = "Trademarks:";
            // 
            // txtCopyright
            // 
            this.txtCopyright.Location = new System.Drawing.Point(231, 219);
            this.txtCopyright.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.Size = new System.Drawing.Size(272, 39);
            this.txtCopyright.TabIndex = 8;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(19, 224);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(125, 32);
            this.lblCopyright.TabIndex = 7;
            this.lblCopyright.Text = "Copyright:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(231, 177);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(272, 39);
            this.txtCompanyName.TabIndex = 6;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(19, 181);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(193, 32);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "Company Name:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(231, 135);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(272, 39);
            this.txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(19, 139);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(141, 32);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(231, 92);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(272, 39);
            this.txtProductName.TabIndex = 2;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(19, 97);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(173, 32);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name:";
            // 
            // groupAsmInfo
            // 
            this.groupAsmInfo.Controls.Add(this.chkChangeAsmInfo);
            this.groupAsmInfo.Controls.Add(this.txtFileVersion);
            this.groupAsmInfo.Controls.Add(this.lblFileVersion);
            this.groupAsmInfo.Controls.Add(this.txtProductVersion);
            this.groupAsmInfo.Controls.Add(this.lblProductVersion);
            this.groupAsmInfo.Controls.Add(this.txtOriginalFilename);
            this.groupAsmInfo.Controls.Add(this.lblOriginalFilename);
            this.groupAsmInfo.Controls.Add(this.txtTrademarks);
            this.groupAsmInfo.Controls.Add(this.lblTrademarks);
            this.groupAsmInfo.Controls.Add(this.txtCopyright);
            this.groupAsmInfo.Controls.Add(this.lblCopyright);
            this.groupAsmInfo.Controls.Add(this.txtCompanyName);
            this.groupAsmInfo.Controls.Add(this.lblCompanyName);
            this.groupAsmInfo.Controls.Add(this.txtDescription);
            this.groupAsmInfo.Controls.Add(this.lblDescription);
            this.groupAsmInfo.Controls.Add(this.txtProductName);
            this.groupAsmInfo.Controls.Add(this.lblProductName);
            this.groupAsmInfo.Location = new System.Drawing.Point(602, 21);
            this.groupAsmInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupAsmInfo.Name = "groupAsmInfo";
            this.groupAsmInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupAsmInfo.Size = new System.Drawing.Size(532, 479);
            this.groupAsmInfo.TabIndex = 3;
            this.groupAsmInfo.TabStop = false;
            this.groupAsmInfo.Text = "Assembly Information";
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(412, 969);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(165, 44);
            this.btnBuild.TabIndex = 4;
            this.btnBuild.Text = "Build client!";
            this.btnBuild.UseVisualStyleBackColor = true;
            // 
            // frmBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1148, 1028);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.groupAsmInfo);
            this.Controls.Add(this.groupInstall);
            this.Controls.Add(this.groupConnection);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova客户端构建";
            this.groupConnection.ResumeLayout(false);
            this.groupConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUAC1)).EndInit();
            this.groupInstall.ResumeLayout(false);
            this.groupInstall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUAC2)).EndInit();
            this.groupAsmInfo.ResumeLayout(false);
            this.groupAsmInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.GroupBox groupConnection;
        private System.Windows.Forms.Label lblMS;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkIconChange;
        private System.Windows.Forms.CheckBox chkElevation;
        private System.Windows.Forms.PictureBox picUAC1;
        private System.Windows.Forms.RadioButton rbSystem;
        private System.Windows.Forms.Label lblRegistryKeyName;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.CheckBox chkHide;
        private System.Windows.Forms.Button btnMutex;
        private System.Windows.Forms.Label lblExamplePath;
        private System.Windows.Forms.TextBox txtExamplePath;
        private System.Windows.Forms.Label lblInstallsub;
        private System.Windows.Forms.Label lblInstallpath;
        private System.Windows.Forms.RadioButton rbAppdata;
        private System.Windows.Forms.TextBox txtMutex;
        private System.Windows.Forms.Label lblMutex;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.TextBox txtInstallname;
        private System.Windows.Forms.Label lblInstallname;
        private System.Windows.Forms.CheckBox chkInstall;
        private System.Windows.Forms.GroupBox groupInstall;
        private System.Windows.Forms.PictureBox picUAC2;
        private System.Windows.Forms.RadioButton rbProgramFiles;
        private System.Windows.Forms.TextBox txtRegistryKeyName;
        private System.Windows.Forms.TextBox txtInstallsub;
        private System.Windows.Forms.CheckBox chkChangeAsmInfo;
        private System.Windows.Forms.TextBox txtFileVersion;
        private System.Windows.Forms.Label lblFileVersion;
        private System.Windows.Forms.TextBox txtProductVersion;
        private System.Windows.Forms.Label lblProductVersion;
        private System.Windows.Forms.TextBox txtOriginalFilename;
        private System.Windows.Forms.Label lblOriginalFilename;
        private System.Windows.Forms.TextBox txtTrademarks;
        private System.Windows.Forms.Label lblTrademarks;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.GroupBox groupAsmInfo;
        private System.Windows.Forms.Button btnBuild;
    }
}