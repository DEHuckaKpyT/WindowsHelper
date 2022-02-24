using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using WindowsHelper.Model;
using WindowsHelper.Repository;

namespace WindowsHelper.Service
{
    internal partial class WindowService : IWindowService
    {
        IGeneralRepository repository = new GeneralRepository();


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

        //todo убрать бы костыль :(
        public IntPtr GetForegroundHandle()
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

            //MessageBox.Show($"{builder}\n" +
            //    $"{process.ProcessName}");

            return intPtr;
        }

        //todo exceptions
        public void SetPositionByHandle(IntPtr handle, int x, int y, int cx, int cy)
        {
            SetWindowPos(handle, 0, x, y, cx, cy, SWP_NOZORDER);
        }

        //todo exceptions
        public void SetPositionByHandleWithoutShadow(IntPtr hWnd, int x, int y, int cx, int cy)
        {
            Rect window = new Rect(x, y, x + cx, y + cy);
            Rect excludeShadow = new Rect();
            Rect includeShadow = new Rect();

            excludeShadow = GetWindowRectangleWithShadow(hWnd);
            GetWindowRect(hWnd, out includeShadow);

            Rect shadow = new Rect();

            shadow.Left = includeShadow.Left - excludeShadow.Left;
            shadow.Right = includeShadow.Right - excludeShadow.Right;
            shadow.Top = includeShadow.Top - excludeShadow.Top;
            shadow.Bottom = includeShadow.Bottom - excludeShadow.Bottom;

            int width = (window.Right + shadow.Right) - (window.Left + shadow.Left);
            int height = (window.Bottom + shadow.Bottom) - (window.Top - shadow.Top);

            SetWindowPos(hWnd, 0, window.Left + shadow.Left, window.Top + shadow.Top, width, height, 0);
        }

        public WindowModel SaveWindowPosition(IntPtr hWnd)
        {
            int foregroundProcessId = 0;
            GetWindowThreadProcessId(hWnd, ref foregroundProcessId);

            WindowModel window = new WindowModel()
            {
                Rectangle = GetWindowRectangleWithShadow(hWnd),
                ProcessName = Process.GetProcessById(foregroundProcessId).ProcessName
            };

            repository.SaveAsync(window);

            return window;
        }
    }
}