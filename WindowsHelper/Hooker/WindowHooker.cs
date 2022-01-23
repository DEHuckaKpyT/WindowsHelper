using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsHelper.Service;

namespace WindowsHelper.Hooker
{
    internal class WindowHooker : IWindowHooker, IDisposable
    {
        private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
        private const uint EVENT_OBJECT_DESTROY = 0x8001;
        private const uint WINEVENT_OUTOFCONTEXT = 0;

        private IntPtr hook = IntPtr.Zero;

        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
            hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
            uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        void Hook()
        {
            var p = Process.GetProcessesByName("notepad").FirstOrDefault();
            if (p != null)
                hook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND,
                IntPtr.Zero, new WinEventDelegate(WinEventProc),
                (uint)p.Id, 0, WINEVENT_OUTOFCONTEXT);
        }

        void WinEventProc(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            string s = "Page Setup";
            StringBuilder sb = new StringBuilder(s.Length + 1);
            WindowService.GetWindowText(hwnd, sb, sb.Capacity);
            //if (sb.ToString() == s)
            //    this.Text = "Page Setup is Open";
            //else
            //    this.Text = "Page Setup is not open";
        }

        public void Dispose()
        {
            UnhookWinEvent(hook);
        }
    }
}
