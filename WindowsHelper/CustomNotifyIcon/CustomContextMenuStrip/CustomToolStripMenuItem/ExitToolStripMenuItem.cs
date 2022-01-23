using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip.CustomToolStripMenuItem
{
    internal class ExitToolStripMenuItem : ToolStripMenuItem
    {
        public ExitToolStripMenuItem()
        {
            Text = "Exit";
            Click += ExitToolStripMenuItem_Click;
        }

        private void ExitToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
