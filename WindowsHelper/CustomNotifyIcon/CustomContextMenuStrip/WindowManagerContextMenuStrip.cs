using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip.CustomToolStripMenuItem;

namespace WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip
{
    internal class WindowManagerContextMenuStrip : ContextMenuStrip
    {
        public WindowManagerContextMenuStrip()
        {
            Items.Add(new SelectWindowToolStripMenuItem());
            Items.Add(new TransparentWindowToolStripMenuItem());
            Items.Add(new ExitToolStripMenuItem());
        }
    }
}
