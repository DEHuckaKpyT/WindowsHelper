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
        private const int SW_HIDE = 0;

        public IDictionary<IntPtr, string> GetOpenWindows()
        {
            //todo remove
            IntPtr shellWindow = GetShellWindow();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr intPtr, int lParam)
            {
                //if (IntPtr == shellWindow) return true;
                if (!IsWindowVisible(intPtr)) return true;

                int length = GetWindowTextLength(intPtr);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(intPtr, builder, length + 1);

                windows[intPtr] = builder.ToString();
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

        //todo убрать бы костыль :(
        public Process GetForeground()
        {
            int currentProcessId = Process.GetCurrentProcess().Id;
            int foregroundProcessId = currentProcessId;

            IntPtr intPtr = IntPtr.Zero;
            StringBuilder builder = new StringBuilder(0);

            while (currentProcessId == foregroundProcessId)
            {
                Thread.Sleep(10);
                intPtr = GetForegroundWindow();
                GetWindowThreadProcessId(intPtr, ref foregroundProcessId);
            }

            int length = GetWindowTextLength(intPtr);

            builder = new StringBuilder(length);
            GetWindowText(intPtr, builder, length + 1);

            Process process = Process.GetProcessById(foregroundProcessId);

            return process;
        }
    }
}
