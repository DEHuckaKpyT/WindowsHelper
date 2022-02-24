using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHelper.Service;

namespace WindowsHelper.CustomForm
{
    public partial class WindowManagerForm : Form
    {
        IWindowService windowService;

        IntPtr windowHandle;

        public WindowManagerForm(IntPtr handle)
        {
            InitializeComponent();
            windowHandle = handle;
            windowService = new WindowService();
        }

        private void button1920x1080_Click(object sender, EventArgs e)
        {
            windowService.SetPositionByHandleWithoutShadow(windowHandle, 0, 0, 1920, 1080);
        }

        private void buttonSaveWindowPosition_Click(object sender, EventArgs e)
        {
            windowService.SaveWindowPosition(windowHandle);
        }
    }
}
