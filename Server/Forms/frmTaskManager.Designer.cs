
namespace Nova.Forms
{
    partial class frmTaskManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskManager));
            this.ctxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxtKillProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtStartProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtLine = new System.Windows.Forms.ToolStripSeparator();
            this.ctxtRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lstTasks = new Nova.Controls.ListViewEx();
            this.hProcessname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxtMenu
            // 
            this.ctxtMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ctxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxtKillProcess,
            this.ctxtStartProcess,
            this.ctxtLine,
            this.ctxtRefresh});
            this.ctxtMenu.Name = "ctxtMenu";
            this.ctxtMenu.Size = new System.Drawing.Size(181, 118);
            // 
            // ctxtKillProcess
            // 
            this.ctxtKillProcess.Image = global::Nova.Properties.Resources.cancel;
            this.ctxtKillProcess.Name = "ctxtKillProcess";
            this.ctxtKillProcess.Size = new System.Drawing.Size(180, 36);
            this.ctxtKillProcess.Text = "结束进程";
            this.ctxtKillProcess.Click += new System.EventHandler(this.ctxtKillProcess_Click);
            // 
            // ctxtStartProcess
            // 
            this.ctxtStartProcess.Image = global::Nova.Properties.Resources.run;
            this.ctxtStartProcess.Name = "ctxtStartProcess";
            this.ctxtStartProcess.Size = new System.Drawing.Size(180, 36);
            this.ctxtStartProcess.Text = "启动进程";
            this.ctxtStartProcess.Click += new System.EventHandler(this.ctxtStartProcess_Click);
            // 
            // ctxtLine
            // 
            this.ctxtLine.Name = "ctxtLine";
            this.ctxtLine.Size = new System.Drawing.Size(177, 6);
            // 
            // ctxtRefresh
            // 
            this.ctxtRefresh.Image = global::Nova.Properties.Resources.refresh;
            this.ctxtRefresh.Name = "ctxtRefresh";
            this.ctxtRefresh.Size = new System.Drawing.Size(180, 36);
            this.ctxtRefresh.Text = "刷新页面";
            this.ctxtRefresh.Click += new System.EventHandler(this.ctxtRefresh_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hProcessname,
            this.hPID,
            this.hTitle});
            this.lstTasks.ContextMenuStrip = this.ctxtMenu;
            this.lstTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTasks.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lstTasks.GridLines = true;
            this.lstTasks.HideSelection = false;
            this.lstTasks.Location = new System.Drawing.Point(0, 0);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(4);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(902, 655);
            this.lstTasks.TabIndex = 0;
            this.lstTasks.UseCompatibleStateImageBehavior = false;
            this.lstTasks.View = System.Windows.Forms.View.Details;
            this.lstTasks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTasks_ColumnClick);
            // 
            // hProcessname
            // 
            this.hProcessname.Text = "Processname";
            this.hProcessname.Width = 271;
            // 
            // hPID
            // 
            this.hPID.Text = "PID";
            this.hPID.Width = 228;
            // 
            // hTitle
            // 
            this.hTitle.Text = "Title";
            this.hTitle.Width = 311;
            // 
            // frmTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 655);
            this.Controls.Add(this.lstTasks);
            this.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(380, 526);
            this.Name = "frmTaskManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova - Task Manager []";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTaskManager_FormClosing);
            this.Load += new System.EventHandler(this.frmTaskManager_Load);
            this.ctxtMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader hProcessname;
        private System.Windows.Forms.ColumnHeader hPID;
        private System.Windows.Forms.ColumnHeader hTitle;
        private System.Windows.Forms.ContextMenuStrip ctxtMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxtKillProcess;
        private System.Windows.Forms.ToolStripMenuItem ctxtStartProcess;
        private System.Windows.Forms.ToolStripSeparator ctxtLine;
        private System.Windows.Forms.ToolStripMenuItem ctxtRefresh;
        public Controls.ListViewEx lstTasks;
    }
}