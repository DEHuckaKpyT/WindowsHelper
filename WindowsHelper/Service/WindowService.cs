using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WindowsHelper.Service
{
    internal partial class WindowService : IWindowService
    {
        private const short SWP_NOMOVE = 0x2;
        private const short SWP_NOSIZE = 1;
        private const short SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;

        public IDictionary<IntPtr, string> GetOpenWindows()
        {
            //todo remove
            IntPtr shellWindow = GetShellWindow();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr IntPtr, int lParam)
            {
                //if (IntPtr == shellWindow) return true;
                if (!IsWindowVisible(IntPtr)) return true;

                int length = GetWindowTextLength(IntPtr);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(IntPtr, builder, length + 1);

                windows[IntPtr] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        public void Move()
        {
            IDictionary<IntPtr, string> dictionary = GetOpenWindows();
            foreach (KeyValuePair<IntPtr, string> window in dictionary)
            {
                IntPtr handle = window.Key;
                string title = window.Value;
                //IntPtr handle = process.MainWindowHandle;

                SetWindowPos(handle, 0, 0, 0, 500, 500, SWP_NOZORDER | SWP_SHOWWINDOW);

                Console.WriteLine("{0}: {1}", handle, title);
            }
        }
    }
}
