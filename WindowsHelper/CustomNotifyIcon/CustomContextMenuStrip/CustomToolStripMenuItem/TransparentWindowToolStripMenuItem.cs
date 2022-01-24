using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelper.CustomForm;

namespace WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip.CustomToolStripMenuItem
{
    internal class TransparentWindowToolStripMenuItem : ToolStripMenuItem
    {
        public TransparentWindowToolStripMenuItem()
        {
            Text = "Show transparent window";
            Click += TransparentWindowToolStripMenuItem_Click;
        }

        private void TransparentWindowToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new TransparentWindowForm().Show();
        }
    }
}
