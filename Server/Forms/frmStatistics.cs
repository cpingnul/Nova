using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmStatistics : Form
    {
        // 网络流量统计（单位：字节）
        long BytesReceived;      // 总共接收的字节数
        long BytesSent;          // 总共发送的字节数
        int ReceivedPercent;     // 接收流量占总流量的百分比
        int SentPercent;         // 发送流量占总流量的百分比

       
        public frmStatistics(long received, long sent)
        {
            BytesReceived = received;
            BytesSent = sent;

            InitializeComponent();
        }
        private int calculate(long value, long sum)
        {
            if (sum != 0)
                return (int)(((float)value / (float)sum) * 100);
            else
                return 0;
        }

        private int calculate(int value, int sum)
        {
            if (sum != 0)
                return (int)(((float)value / (float)sum) * 100);
            else
                return 0;
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            long sum = BytesReceived + BytesSent;
            int received = calculate(BytesReceived, sum);
            int sent = calculate(BytesSent, sum);
            if (received + sent != 100)
                received += 1;

            if (received + sent != 100)
                received += 1;

            ReceivedPercent = received;
            SentPercent = sent;

        }

        private void tabTraffic_Paint(object sender, PaintEventArgs e)
        {
            if (BytesReceived != 0 && BytesSent != 0)
            {
                int[] myPiePercents = { ReceivedPercent, SentPercent };

                Color[] PieColors = { Color.Green, Color.Blue };

                Size PieSize = new Size(350, 350);

                if (myPiePercents[0] + myPiePercents[1] != 100)
                    myPiePercents[0] += 2;
                else
                    myPiePercents[0] += 1;

                int sum = 0;
                foreach (int percent_loopVariable in myPiePercents)
                    sum += percent_loopVariable;

                int PiePercentTotal = 0;
                for (int PiePercents = 0; PiePercents < myPiePercents.Length; PiePercents++)
                {
                    using (SolidBrush brush = new SolidBrush(PieColors[PiePercents]))
                    {
                        e.Graphics.FillPie(brush, new Rectangle(new Point(25, 50), PieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePercents[PiePercents] * 360 / 100));
                    }
                    PiePercentTotal += myPiePercents[PiePercents];
                }

                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Green), 15), new Point(450, 130), new Point(790, 130));
                e.Graphics.DrawString(BytesReceived + " Bytes received (" + ReceivedPercent + "%)", this.Font, new SolidBrush(Color.Black), new Point(460, 140));

                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Blue), 15), new Point(450, 220), new Point(790, 220));
                e.Graphics.DrawString(BytesSent + " Bytes sent (" + SentPercent + "%)", this.Font, new SolidBrush(Color.Black), new Point(460, 230));
            }
        }
    }
}
