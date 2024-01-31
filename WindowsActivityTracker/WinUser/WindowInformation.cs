
using DomainLogic.Repositories;
using System.Runtime.InteropServices;

namespace WinUser
{
    public class WindowInformation : IWindowInformation
    {
        [DllImport("user32.dll")]
        private static extern nint GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(nint hWnd, string lpString, int nMaxCount);

        public string GetWindowTitle()
        {
            nint foregroundWindow = GetForegroundWindow();
            const int maxPathSize = 256;
            string windowTitle = new(' ', maxPathSize);

            //TODO check error management for this function
            GetWindowText(foregroundWindow, windowTitle, maxPathSize);

            return windowTitle;
        }
    }
}