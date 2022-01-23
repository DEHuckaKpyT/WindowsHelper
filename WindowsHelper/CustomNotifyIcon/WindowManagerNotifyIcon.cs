using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip;

namespace WindowsHelper.CustomNotifyIcon
{
    internal class WindowManagerNotifyIcon
    {
        public NotifyIcon NotifyIcon { get; set; }
        public WindowManagerNotifyIcon()
        {
            NotifyIcon = new NotifyIcon();
            NotifyIcon.Text = "WindowManeger";
            NotifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            NotifyIcon.ContextMenuStrip = new WindowManagerContextMenuStrip();
            NotifyIcon.Visible = true;
        }
    }
}
