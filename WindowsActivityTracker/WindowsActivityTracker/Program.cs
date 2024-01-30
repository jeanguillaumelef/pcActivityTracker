using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetWindowText(IntPtr hWnd, string lpString, int nMaxCount);

    static void Main()
    {
        while (true)
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            const int maxPathSize = 256;
            string windowTitle = new string(' ', maxPathSize);

            GetWindowText(foregroundWindow, windowTitle, maxPathSize);
            windowTitle = windowTitle.Split('\\').Last();

            Console.WriteLine("Active Window: " + windowTitle);

            // Sleep for a short interval
            System.Threading.Thread.Sleep(1000);
        }
    }
}

