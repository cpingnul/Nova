
namespace Nova.Forms
{
    partial class frmSystemInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemInformation));
            this.ctxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxtCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSystem = new Nova.Controls.ListViewEx();
            this.hComponent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxtMenu
            // 
            this.ctxtMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ctxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxtCopy});
            this.ctxtMenu.Name = "ctxtMenu";
            this.ctxtMenu.Size = new System.Drawing.Size(136, 38);
            // 
            // ctxtCopy
            // 
            this.ctxtCopy.Name = "ctxtCopy";
            this.ctxtCopy.Size = new System.Drawing.Size(135, 34);
            this.ctxtCopy.Text = "Copy";
            this.ctxtCopy.Click += new System.EventHandler(this.ctxtCopy_Click);
            // 
            // lstSystem
            // 
            this.lstSystem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hComponent,
            this.hValue});
            this.lstSystem.ContextMenuStrip = this.ctxtMenu;
            this.lstSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSystem.FullRowSelect = true;
            this.lstSystem.GridLines = true;
            this.lstSystem.HideSelection = false;
            this.lstSystem.Location = new System.Drawing.Point(0, 0);
            this.lstSystem.Margin = new System.Windows.Forms.Padding(4);
            this.lstSystem.Name = "lstSystem";
            this.lstSystem.Size = new System.Drawing.Size(871, 626);
            this.lstSystem.TabIndex = 0;
            this.lstSystem.UseCompatibleStateImageBehavior = false;
            this.lstSystem.View = System.Windows.Forms.View.Details;
            // 
            // hComponent
            // 
            this.hComponent.Text = "Component";
            this.hComponent.Width = 193;
            // 
            // hValue
            // 
            this.hValue.Text = "Value";
            this.hValue.Width = 529;
            // 
            // frmSystemInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 626);
            this.Controls.Add(this.lstSystem);
            this.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova - System Information []";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSystemInformation_FormClosing);
            this.Load += new System.EventHandler(this.frmSystemInformation_Load);
            this.ctxtMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader hComponent;
        private System.Windows.Forms.ColumnHeader hValue;
        public Controls.ListViewEx lstSystem;
        private System.Windows.Forms.ContextMenuStrip ctxtMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxtCopy;
    }
}