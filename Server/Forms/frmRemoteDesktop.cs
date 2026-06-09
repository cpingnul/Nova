using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmRemoteDesktop : Form
    {
        private Client cClient;
        private bool keepRunning;
        private bool enableMouseInput;
        public frmRemoteDesktop(Client c)
        {
            cClient = c;
            cClient.Value.frmRDP = this;
            keepRunning = false;
            enableMouseInput = false;
            InitializeComponent();
        }

        private void frmRemoteDesktop_Load(object sender, EventArgs e)

        {
            this.Text = string.Format("Nova - 远程桌面 [{0}:{1}]", cClient.EndPoint.Address.ToString(), cClient.EndPoint.Port.ToString());

            panelTop.Left = (this.Width / 2) - (panelTop.Width / 2);

            btnShow.Location = new System.Drawing.Point(588, 0);
            btnShow.Left = (this.Width / 2) - (btnShow.Width / 2);

            if (cClient.Value != null)
                cClient.Send(new Nova.Packets.ServerPackets.Monitors());
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            panelTop.Visible = true;
            btnShow.Visible = false;
            btnHide.Visible = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            btnShow.Visible = true;
            btnHide.Visible = false;
        }

        private void frmRemoteDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            keepRunning = false;
            if (cClient.Value != null)
                cClient.Value.frmRDP = null;
        }
        private void getDesktop()
        {
            keepRunning = true;

            while (keepRunning)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                    });

                    if (cClient.Value != null)
                    {
                        if (true)
                        {
                            int Quality = 1;
                            int number = 1;
                            this.Invoke((MethodInvoker)delegate
                            {
                                Quality = barQuality.Value;
                                number = cbMonitors.SelectedIndex;
                            });

                            cClient.Send(new Nova.Packets.ServerPackets.Desktop(Quality, number));
                            cClient.Value.lastDesktopSeen = false;
                        }
                    }
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            keepRunning = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!keepRunning)
                new Thread(getDesktop).Start();
            else
                keepRunning = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            keepRunning = false;
        }

        private void barQuality_Scroll(object sender, EventArgs e)
        {
            switch (barQuality.Value)
            {
                case 1:
                    lblQualityShow.Text = "速度";
                    break;
                case 2:
                    lblQualityShow.Text = "质量";
                    break;
            }
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            if (enableMouseInput)
            {
                this.picDesktop.Cursor = Cursors.Default;
                btnMouse.Image = global::Nova.Properties.Resources.mouse_delete;
                enableMouseInput = false;
            }
            else
            {
                this.picDesktop.Cursor = Cursors.Hand;
                btnMouse.Image = global::Nova.Properties.Resources.mouse_add;
                enableMouseInput = true;
            }
        }
        private Rectangle GetImageDisplayRect()
        {
            if (picDesktop.Image == null) return Rectangle.Empty;

            int imgW = picDesktop.Image.Width;
            int imgH = picDesktop.Image.Height;
            int boxW = picDesktop.Width;
            int boxH = picDesktop.Height;

            // 计算缩放比例
            float scaleW = (float)boxW / imgW;
            float scaleH = (float)boxH / imgH;
            float scale = Math.Min(scaleW, scaleH);  // Zoom 模式取最小比例

            int displayW = (int)(imgW * scale);
            int displayH = (int)(imgH * scale);

            // 计算居中偏移
            int offsetX = (boxW - displayW) / 2;
            int offsetY = (boxH - displayH) / 2;

            return new Rectangle(offsetX, offsetY, displayW, displayH);
        }
        private void picDesktop_MouseClick(object sender, MouseEventArgs e)
        {
            if (picDesktop.Image != null && enableMouseInput)
            {
                Rectangle imageRect = GetImageDisplayRect();
             
                // 检查是否点击在图像区域内
                if (!imageRect.Contains(e.X, e.Y))
                {
                    return;
                }

                // 计算相对于图像区域的坐标
                int relativeX = e.X - imageRect.X;
                int relativeY = e.Y - imageRect.Y;

                // 转换为原始图像坐标
                int remote_x = (int)((float)relativeX / imageRect.Width * picDesktop.Image.Width);
                int remote_y = (int)((float)relativeY / imageRect.Height * picDesktop.Image.Height);
      
                // 边界检查
                remote_x = Math.Max(0, Math.Min(remote_x, picDesktop.Image.Width - 1));
                remote_y = Math.Max(0, Math.Min(remote_y, picDesktop.Image.Height - 1));

                bool left = (e.Button == MouseButtons.Left);    

                if (cClient != null)
                    cClient.Send(new Nova.Packets.ServerPackets.MouseClick(left, false, remote_x, remote_y));
            }
        }

        private void picDesktop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (picDesktop.Image != null && enableMouseInput)
            {
                // 获取缩放后的图像实际显示区域
                Rectangle imageRect = GetImageDisplayRect();

                // 检查是否点击在图像区域内
                if (!imageRect.Contains(e.X, e.Y))
                    return;

                // 计算相对于图像区域的坐标
                int relativeX = e.X - imageRect.X;
                int relativeY = e.Y - imageRect.Y;

                // 转换为原始图像坐标
                int remote_x = (int)((float)relativeX / imageRect.Width * picDesktop.Image.Width);
                int remote_y = (int)((float)relativeY / imageRect.Height * picDesktop.Image.Height);

                // 边界检查
                remote_x = Math.Max(0, Math.Min(remote_x, picDesktop.Image.Width - 1));
                remote_y = Math.Max(0, Math.Min(remote_y, picDesktop.Image.Height - 1));

                bool left = (e.Button == MouseButtons.Left);

                if (cClient != null)
                    cClient.Send(new Nova.Packets.ServerPackets.MouseClick(left, true, remote_x, remote_y));
            }
        }

        private void frmRemoteDeskto_Resize(object sender, EventArgs e)
        {
            panelTop.Left = (this.Width / 2) - (panelTop.Width / 2);
            btnShow.Left = (this.Width / 2) - (btnShow.Width / 2);
        }
    }
}