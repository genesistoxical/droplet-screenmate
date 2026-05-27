using System;
using System.Runtime.InteropServices;

namespace DropletScreenmate
{
    internal class InactiveWindow
    {
        internal const int GWL_EXSTYLE = -20;
        internal static int WS_EX_NOACTIVATE = 0x08000000;
        internal static int WS_EX_TOOLWINDOW = 0x00000080;

        [DllImport("user32.dll")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
