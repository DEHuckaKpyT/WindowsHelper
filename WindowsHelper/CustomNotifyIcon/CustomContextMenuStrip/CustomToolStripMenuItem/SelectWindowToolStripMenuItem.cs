using System.Diagnostics;
using WindowsHelper.Hooker.MouseAndKeyboard;
using WindowsHelper.Service;

namespace WindowsHelper.CustomNotifyIcon.CustomContextMenuStrip.CustomToolStripMenuItem
{
    internal class SelectWindowToolStripMenuItem : ToolStripMenuItem
    {
        WindowService windowService;
        public SelectWindowToolStripMenuItem()
        {
            windowService = new WindowService();
            Text = "Select a window";
            Click += SelectWindowToolStripMenuItem_Click;
        }

        private void SelectWindowToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            MouseAndKeyboardHooker.MouseClickExt += MouseAndKeyboardHooker_MouseClickExt;
        }

        private void MouseAndKeyboardHooker_MouseClickExt(object? sender, MouseEventExtArgs e)
        {
            MouseAndKeyboardHooker.MouseClickExt -= MouseAndKeyboardHooker_MouseClickExt;
            Process process = windowService.GetForeground();
        }
    }
}
