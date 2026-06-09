
namespace Nova.Forms
{
    partial class frmFileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileManager));
            this.TabControlFileManager = new System.Windows.Forms.TabControl();
            this.tabFileExplorer = new System.Windows.Forms.TabPage();
            this.btnOpenDLFolder = new System.Windows.Forms.Button();
            this.lblDrive = new System.Windows.Forms.Label();
            this.cmbDrives = new System.Windows.Forms.ComboBox();
            this.lstDirectory = new Nova.Controls.ListViewEx();
            this.hName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxtDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxtExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtLine = new System.Windows.Forms.ToolStripSeparator();
            this.ctxtRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListDirectory = new System.Windows.Forms.ImageList(this.components);
            this.tabTransfers = new System.Windows.Forms.TabPage();
            this.lstTransfers = new Nova.Controls.ListViewEx();
            this.hID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgListTransfers = new System.Windows.Forms.ImageList(this.components);
            this.botStrip = new System.Windows.Forms.StatusStrip();
            this.TabControlFileManager.SuspendLayout();
            this.tabFileExplorer.SuspendLayout();
            this.ctxtMenu.SuspendLayout();
            this.tabTransfers.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlFileManager
            // 
            this.TabControlFileManager.Controls.Add(this.tabFileExplorer);
            this.TabControlFileManager.Controls.Add(this.tabTransfers);
            this.TabControlFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlFileManager.Location = new System.Drawing.Point(0, 0);
            this.TabControlFileManager.Margin = new System.Windows.Forms.Padding(4);
            this.TabControlFileManager.Name = "TabControlFileManager";
            this.TabControlFileManager.SelectedIndex = 0;
            this.TabControlFileManager.Size = new System.Drawing.Size(1372, 760);
            this.TabControlFileManager.TabIndex = 0;
            // 
            // tabFileExplorer
            // 
            this.tabFileExplorer.Controls.Add(this.btnOpenDLFolder);
            this.tabFileExplorer.Controls.Add(this.lblDrive);
            this.tabFileExplorer.Controls.Add(this.cmbDrives);
            this.tabFileExplorer.Controls.Add(this.lstDirectory);
            this.tabFileExplorer.Location = new System.Drawing.Point(4, 41);
            this.tabFileExplorer.Margin = new System.Windows.Forms.Padding(4);
            this.tabFileExplorer.Name = "tabFileExplorer";
            this.tabFileExplorer.Padding = new System.Windows.Forms.Padding(4);
            this.tabFileExplorer.Size = new System.Drawing.Size(1364, 715);
            this.tabFileExplorer.TabIndex = 0;
            this.tabFileExplorer.Text = "文件浏览";
            this.tabFileExplorer.UseVisualStyleBackColor = true;
            // 
            // btnOpenDLFolder
            // 
            this.btnOpenDLFolder.Location = new System.Drawing.Point(1019, 21);
            this.btnOpenDLFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenDLFolder.Name = "btnOpenDLFolder";
            this.btnOpenDLFolder.Size = new System.Drawing.Size(307, 56);
            this.btnOpenDLFolder.TabIndex = 7;
            this.btnOpenDLFolder.Text = "打开下载文件目录";
            this.btnOpenDLFolder.UseVisualStyleBackColor = true;
            this.btnOpenDLFolder.Click += new System.EventHandler(this.btnOpenDLFolder_Click);
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(21, 24);
            this.lblDrive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(90, 32);
            this.lblDrive.TabIndex = 5;
            this.lblDrive.Text = "设备：";
            // 
            // cmbDrives
            // 
            this.cmbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrives.FormattingEnabled = true;
            this.cmbDrives.Location = new System.Drawing.Point(138, 21);
            this.cmbDrives.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDrives.Name = "cmbDrives";
            this.cmbDrives.Size = new System.Drawing.Size(203, 40);
            this.cmbDrives.TabIndex = 6;
            this.cmbDrives.SelectedIndexChanged += new System.EventHandler(this.cmbDrives_SelectedIndexChanged);
            // 
            // lstDirectory
            // 
            this.lstDirectory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hName,
            this.hSize,
            this.hType});
            this.lstDirectory.ContextMenuStrip = this.ctxtMenu;
            this.lstDirectory.GridLines = true;
            this.lstDirectory.HideSelection = false;
            this.lstDirectory.Location = new System.Drawing.Point(27, 93);
            this.lstDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.lstDirectory.Name = "lstDirectory";
            this.lstDirectory.Size = new System.Drawing.Size(1299, 577);
            this.lstDirectory.SmallImageList = this.imgListDirectory;
            this.lstDirectory.TabIndex = 0;
            this.lstDirectory.UseCompatibleStateImageBehavior = false;
            this.lstDirectory.View = System.Windows.Forms.View.Details;
            this.lstDirectory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstDirectory_ColumnClick);
            this.lstDirectory.DoubleClick += new System.EventHandler(this.lstDirectory_DoubleClick);
            // 
            // hName
            // 
            this.hName.Text = "名字";
            this.hName.Width = 307;
            // 
            // hSize
            // 
            this.hSize.Text = "大小";
            this.hSize.Width = 288;
            // 
            // hType
            // 
            this.hType.Text = "类型";
            this.hType.Width = 487;
            // 
            // ctxtMenu
            // 
            this.ctxtMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.ctxtMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ctxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxtDownload,
            this.ctxtLine2,
            this.ctxtExecute,
            this.ctxtRename,
            this.ctxtDelete,
            this.ctxtLine,
            this.ctxtRefresh});
            this.ctxtMenu.Name = "ctxtMenu";
            this.ctxtMenu.Size = new System.Drawing.Size(155, 226);
            // 
            // ctxtDownload
            // 
            this.ctxtDownload.Image = global::Nova.Properties.Resources.download;
            this.ctxtDownload.Name = "ctxtDownload";
            this.ctxtDownload.Size = new System.Drawing.Size(154, 42);
            this.ctxtDownload.Text = "下载";
            this.ctxtDownload.Click += new System.EventHandler(this.ctxtDownload_Click);
            // 
            // ctxtLine2
            // 
            this.ctxtLine2.Name = "ctxtLine2";
            this.ctxtLine2.Size = new System.Drawing.Size(151, 6);
            // 
            // ctxtExecute
            // 
            this.ctxtExecute.Image = global::Nova.Properties.Resources.run;
            this.ctxtExecute.Name = "ctxtExecute";
            this.ctxtExecute.Size = new System.Drawing.Size(154, 42);
            this.ctxtExecute.Text = "执行";
            this.ctxtExecute.Click += new System.EventHandler(this.ctxtExecute_Click);
            // 
            // ctxtRename
            // 
            this.ctxtRename.Image = global::Nova.Properties.Resources.textfield_rename;
            this.ctxtRename.Name = "ctxtRename";
            this.ctxtRename.Size = new System.Drawing.Size(154, 42);
            this.ctxtRename.Text = "命名";
            // 
            // ctxtDelete
            // 
            this.ctxtDelete.Image = global::Nova.Properties.Resources.delete;
            this.ctxtDelete.Name = "ctxtDelete";
            this.ctxtDelete.Size = new System.Drawing.Size(154, 42);
            this.ctxtDelete.Text = "删除";
            // 
            // ctxtLine
            // 
            this.ctxtLine.Name = "ctxtLine";
            this.ctxtLine.Size = new System.Drawing.Size(151, 6);
            // 
            // ctxtRefresh
            // 
            this.ctxtRefresh.Image = global::Nova.Properties.Resources.refresh;
            this.ctxtRefresh.Name = "ctxtRefresh";
            this.ctxtRefresh.Size = new System.Drawing.Size(154, 42);
            this.ctxtRefresh.Text = "刷新";
            this.ctxtRefresh.Click += new System.EventHandler(this.ctxtRefresh_Click);
            // 
            // imgListDirectory
            // 
            this.imgListDirectory.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListDirectory.ImageStream")));
            this.imgListDirectory.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListDirectory.Images.SetKeyName(0, "back.png");
            this.imgListDirectory.Images.SetKeyName(1, "folder.png");
            this.imgListDirectory.Images.SetKeyName(2, "file.png");
            this.imgListDirectory.Images.SetKeyName(3, "application.png");
            this.imgListDirectory.Images.SetKeyName(4, "text.png");
            this.imgListDirectory.Images.SetKeyName(5, "archive.png");
            this.imgListDirectory.Images.SetKeyName(6, "word.png");
            this.imgListDirectory.Images.SetKeyName(7, "pdf.png");
            this.imgListDirectory.Images.SetKeyName(8, "image.png");
            this.imgListDirectory.Images.SetKeyName(9, "movie.png");
            this.imgListDirectory.Images.SetKeyName(10, "music.png");
            // 
            // tabTransfers
            // 
            this.tabTransfers.Controls.Add(this.lstTransfers);
            this.tabTransfers.Location = new System.Drawing.Point(4, 41);
            this.tabTransfers.Margin = new System.Windows.Forms.Padding(4);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Padding = new System.Windows.Forms.Padding(4);
            this.tabTransfers.Size = new System.Drawing.Size(1364, 715);
            this.tabTransfers.TabIndex = 1;
            this.tabTransfers.Text = "传输情况";
            this.tabTransfers.UseVisualStyleBackColor = true;
            // 
            // lstTransfers
            // 
            this.lstTransfers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hID,
            this.hStatus,
            this.hFilename});
            this.lstTransfers.GridLines = true;
            this.lstTransfers.HideSelection = false;
            this.lstTransfers.Location = new System.Drawing.Point(9, 8);
            this.lstTransfers.Margin = new System.Windows.Forms.Padding(4);
            this.lstTransfers.Name = "lstTransfers";
            this.lstTransfers.Size = new System.Drawing.Size(1346, 666);
            this.lstTransfers.TabIndex = 0;
            this.lstTransfers.UseCompatibleStateImageBehavior = false;
            this.lstTransfers.View = System.Windows.Forms.View.Details;
            // 
            // hID
            // 
            this.hID.Text = "ID";
            this.hID.Width = 273;
            // 
            // hStatus
            // 
            this.hStatus.Text = "Status";
            this.hStatus.Width = 402;
            // 
            // hFilename
            // 
            this.hFilename.Text = "Filename";
            this.hFilename.Width = 611;
            // 
            // imgListTransfers
            // 
            this.imgListTransfers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTransfers.ImageStream")));
            this.imgListTransfers.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListTransfers.Images.SetKeyName(0, "cancel.png");
            this.imgListTransfers.Images.SetKeyName(1, "done.png");
            // 
            // botStrip
            // 
            this.botStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.botStrip.Location = new System.Drawing.Point(0, 738);
            this.botStrip.Name = "botStrip";
            this.botStrip.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.botStrip.Size = new System.Drawing.Size(1372, 22);
            this.botStrip.TabIndex = 4;
            this.botStrip.Text = "statusStrip1";
            // 
            // frmFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 760);
            this.Controls.Add(this.botStrip);
            this.Controls.Add(this.TabControlFileManager);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmFileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova - 文件管理 []";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFileManager_FormClosing);
            this.Load += new System.EventHandler(this.frmFileManager_Load);
            this.TabControlFileManager.ResumeLayout(false);
            this.tabFileExplorer.ResumeLayout(false);
            this.tabFileExplorer.PerformLayout();
            this.ctxtMenu.ResumeLayout(false);
            this.tabTransfers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlFileManager;
        private System.Windows.Forms.TabPage tabFileExplorer;
        private System.Windows.Forms.TabPage tabTransfers;
        private System.Windows.Forms.Button btnOpenDLFolder;
        private System.Windows.Forms.Label lblDrive;
        public System.Windows.Forms.ComboBox cmbDrives;
        private System.Windows.Forms.ColumnHeader hName;
        private System.Windows.Forms.ColumnHeader hSize;
        private System.Windows.Forms.ColumnHeader hType;
        private System.Windows.Forms.ImageList imgListTransfers;
        private System.Windows.Forms.ImageList imgListDirectory;
        private System.Windows.Forms.ContextMenuStrip ctxtMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxtDownload;
        private System.Windows.Forms.ToolStripSeparator ctxtLine2;
        private System.Windows.Forms.ToolStripMenuItem ctxtExecute;
        private System.Windows.Forms.ToolStripMenuItem ctxtRename;
        private System.Windows.Forms.ToolStripMenuItem ctxtDelete;
        private System.Windows.Forms.ToolStripSeparator ctxtLine;
        private System.Windows.Forms.ToolStripMenuItem ctxtRefresh;
        public System.Windows.Forms.StatusStrip botStrip;
        public Controls.ListViewEx lstDirectory;
        private System.Windows.Forms.ColumnHeader hID;
        private System.Windows.Forms.ColumnHeader hStatus;
        private System.Windows.Forms.ColumnHeader hFilename;
        public Controls.ListViewEx lstTransfers;
    }
}