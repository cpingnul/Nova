
namespace Nova.Elevation
{
    partial class frmElevation
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
            this.panelBot = new System.Windows.Forms.Panel();
            this.linkError = new System.Windows.Forms.LinkLabel();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.lblHead = new System.Windows.Forms.Label();
            this.btnRestoreAndCheck = new Nova.Elevation.CommandButton();
            this.btnRestore = new Nova.Elevation.CommandButton();
            this.panelBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBot
            // 
            this.panelBot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBot.Controls.Add(this.linkError);
            this.panelBot.Controls.Add(this.picInfo);
            this.panelBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBot.Location = new System.Drawing.Point(0, 415);
            this.panelBot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelBot.Name = "panelBot";
            this.panelBot.Size = new System.Drawing.Size(848, 49);
            this.panelBot.TabIndex = 8;
            // 
            // linkError
            // 
            this.linkError.AutoSize = true;
            this.linkError.Location = new System.Drawing.Point(43, 9);
            this.linkError.Name = "linkError";
            this.linkError.Size = new System.Drawing.Size(186, 32);
            this.linkError.TabIndex = 1;
            this.linkError.TabStop = true;
            this.linkError.Text = "%MOREDETAILS";
            this.linkError.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkError_LinkClicked);
            // 
            // picInfo
            // 
            this.picInfo.Image = global::Nova.Properties.Resources.information;
            this.picInfo.Location = new System.Drawing.Point(14, 18);
            this.picInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(16, 16);
            this.picInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInfo.TabIndex = 0;
            this.picInfo.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(91, 67);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(107, 32);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "%TEXT%";
            // 
            // picError
            // 
            this.picError.Location = new System.Drawing.Point(14, 21);
            this.picError.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(42, 42);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picError.TabIndex = 7;
            this.picError.TabStop = false;
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHead.Location = new System.Drawing.Point(88, 21);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(143, 37);
            this.lblHead.TabIndex = 6;
            this.lblHead.Text = "%ERROR%";
            // 
            // btnRestoreAndCheck
            // 
            this.btnRestoreAndCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRestoreAndCheck.Location = new System.Drawing.Point(0, 334);
            this.btnRestoreAndCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRestoreAndCheck.MaximumSize = new System.Drawing.Size(848, 70);
            this.btnRestoreAndCheck.MinimumSize = new System.Drawing.Size(848, 70);
            this.btnRestoreAndCheck.Name = "btnRestoreAndCheck";
            this.btnRestoreAndCheck.Size = new System.Drawing.Size(848, 70);
            this.btnRestoreAndCheck.TabIndex = 12;
            this.btnRestoreAndCheck.Text = "%RESTOREANDCHECK%";
            this.btnRestoreAndCheck.UseVisualStyleBackColor = true;
            this.btnRestoreAndCheck.Click += new System.EventHandler(this.btnRestoreAndCheck_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRestore.Location = new System.Drawing.Point(0, 264);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(848, 70);
            this.btnRestore.TabIndex = 11;
            this.btnRestore.Text = "%RESTORE%";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // frmElevation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 464);
            this.Controls.Add(this.btnRestoreAndCheck);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.panelBot);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.lblHead);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmElevation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "%TITLE%";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmElevation_Paint);
            this.panelBot.ResumeLayout(false);
            this.panelBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBot;
        private System.Windows.Forms.LinkLabel linkError;
        private System.Windows.Forms.PictureBox picInfo;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Label lblHead;
        private Elevation.CommandButton btnRestoreAndCheck;
        private Elevation.CommandButton btnRestore;
    }
}