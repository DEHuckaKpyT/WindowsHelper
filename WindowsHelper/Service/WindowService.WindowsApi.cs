using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Service
{
    internal partial class WindowService
    {
        private delegate bool EnumWindowsProc(IntPtr IntPtr, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr IntPtr);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr IntPtr);

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern IntPtr SetWindowPos(IntPtr IntPtr, int IntPtrInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    }
}
