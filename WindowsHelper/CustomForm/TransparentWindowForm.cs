using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.CustomForm
{
    public partial class TransparentWindowForm : Form
    {
        private const int gripSize = 16;      // Grip size
        private const int captionHeight = 32;   // Caption bar height;
        private Brush captionBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        Graphics graphics;
        Thread screenThread;

        public TransparentWindowForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.TransparencyKey = BackColor;

            graphics = CreateGraphics();
            screenThread = new Thread(new ThreadStart(TakeScreenshots));
        }

        private void TransparentWindowForm_Load(object sender, EventArgs e)
        {
            screenThread.Start();
        }

        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void TakeScreenshots()
        {
            Bitmap screenshot = new Bitmap(ClientSize.Width, ClientSize.Height);

            while (true)
            {
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    await Task.Run(() =>
                    {
                        g.CopyFromScreen(Location, Point.Empty, ClientSize);
                    });
                }
                await Task.Run(() => graphics.DrawImage(screenshot, 0, 0));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            //Rectangle rc = new Rectangle(this.ClientSize.Width - gripSize, this.ClientSize.Height - gripSize, gripSize, gripSize);
            //ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            //rc = new Rectangle(0, 0, this.ClientSize.Width, captionHeight);
            //e.Graphics.FillRectangle(captionBrush, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < ClientSize.Height / 2)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width / 2 && pos.Y >= this.ClientSize.Height / 2)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
                if (pos.X < this.ClientSize.Width / 2 && pos.Y >= this.ClientSize.Height / 2)
                {
                    m.Result = (IntPtr)16; // HTBOTTOMLEFT
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
