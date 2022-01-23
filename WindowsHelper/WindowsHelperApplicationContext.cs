using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelper.CustomNotifyIcon;

namespace WindowsHelper
{
    internal class WindowsHelperApplicationContext : ApplicationContext
    {
        private WindowManagerNotifyIcon notifyIcon;

        public WindowsHelperApplicationContext()
        {
            notifyIcon = new WindowManagerNotifyIcon();

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void OnApplicationExit(object? sender, EventArgs e)
        {
            notifyIcon.NotifyIcon.Dispose();
        }
    }
}
