
namespace Nova.Forms
{
    partial class frmTermsOfUse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTermsOfUse));
            this.lblToU = new System.Windows.Forms.Label();
            this.rtxtContent = new System.Windows.Forms.RichTextBox();
            this.chkDontShowAgain = new System.Windows.Forms.CheckBox();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblToU
            // 
            this.lblToU.AutoSize = true;
            this.lblToU.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblToU.Location = new System.Drawing.Point(12, 11);
            this.lblToU.Name = "lblToU";
            this.lblToU.Size = new System.Drawing.Size(182, 50);
            this.lblToU.TabIndex = 1;
            this.lblToU.Text = "使用条款";
            // 
            // rtxtContent
            // 
            this.rtxtContent.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtContent.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rtxtContent.Location = new System.Drawing.Point(12, 82);
            this.rtxtContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.ReadOnly = true;
            this.rtxtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtContent.Size = new System.Drawing.Size(705, 288);
            this.rtxtContent.TabIndex = 0;
            this.rtxtContent.Text = "";
            // 
            // chkDontShowAgain
            // 
            this.chkDontShowAgain.AutoSize = true;
            this.chkDontShowAgain.Location = new System.Drawing.Point(12, 403);
            this.chkDontShowAgain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDontShowAgain.Name = "chkDontShowAgain";
            this.chkDontShowAgain.Size = new System.Drawing.Size(138, 32);
            this.chkDontShowAgain.TabIndex = 5;
            this.chkDontShowAgain.Text = "不要再显示";
            this.chkDontShowAgain.UseVisualStyleBackColor = true;
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(473, 393);
            this.btnDecline.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(120, 58);
            this.btnDecline.TabIndex = 7;
            this.btnDecline.Text = "拒绝";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAccept.Location = new System.Drawing.Point(599, 393);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(118, 58);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "接受";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmTermsOfUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 464);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkDontShowAgain);
            this.Controls.Add(this.rtxtContent);
            this.Controls.Add(this.lblToU);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmTermsOfUse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova - 使用条款";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTermsOfUse_FormClosing);
            this.Load += new System.EventHandler(this.frmTermsOfUse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToU;
        private System.Windows.Forms.RichTextBox rtxtContent;
        private System.Windows.Forms.CheckBox chkDontShowAgain;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAccept;
    }
}