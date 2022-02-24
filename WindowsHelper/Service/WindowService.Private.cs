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
        private Rect GetWindowRectangleWithShadow(IntPtr hWnd)
        {
            Rect rect;

            int size = Marshal.SizeOf(typeof(Rect));
            DwmGetWindowAttribute(hWnd, (int)DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, size);

            return rect;
        }

        private Rect GetWindowRectangle(IntPtr hWnd)
        {
            Rect includeShadow = new Rect();

            GetWindowRect(hWnd, out includeShadow);

            return includeShadow;
        }
    }
}
