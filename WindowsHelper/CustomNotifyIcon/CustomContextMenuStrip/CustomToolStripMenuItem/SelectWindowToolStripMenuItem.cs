using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip.CustomToolStripMenuItem
{
    internal class SelectWindowToolStripMenuItem : ToolStripMenuItem
    {
        public SelectWindowToolStripMenuItem()
        {
            Text = "Select a window";
            Click += SelectWindowToolStripMenuItem_Click;
        }

        private void SelectWindowToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("hah");
        }
    }
}
