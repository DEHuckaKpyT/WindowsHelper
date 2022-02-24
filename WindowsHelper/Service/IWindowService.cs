using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHelper.Model;
using static WindowsHelper.Service.WindowService;

namespace WindowsHelper.Service
{
    internal interface IWindowService
    {
        WindowModel SaveWindowPosition(IntPtr hWnd);
        void SetPositionByHandle(IntPtr handle, int x, int y, int cx, int cy);

        void SetPositionByHandleWithoutShadow(IntPtr handle, int x, int y, int cx, int cy);

        //Rect GetWindowRectangle(IntPtr hWnd);
    }
}
