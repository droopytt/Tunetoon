using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tunetoon.Game;

public static class WindowUtils
{
    private static readonly string Keys = "^";

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle rectangle);
    
    [DllImport("user32.dll")]
    private static extern int GetClientRect(IntPtr hWnd, ref Rectangle rectangle);
    
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hWnd);

    public static void Resize(IntPtr windowPtr, int x, int y, int width, int height)
    {
        SetWindowPos(windowPtr, IntPtr.Zero, x, y, width, height, 0);
    }

    public static void SendKeyToWindow(IntPtr windowPtr)
    {
        SetForegroundWindow(windowPtr);
        SendKeys.SendWait(Keys);
    }
    
    public static Rectangle GetWindowRectangle(IntPtr windowPtr)
    {
        Rectangle rectangle = new Rectangle();
        GetWindowRect(windowPtr, ref rectangle);
        return rectangle;
    }


    public static Rectangle GetClientRectangle(IntPtr windowPtr)
    {
        Rectangle rectangle = new Rectangle();
        GetClientRect(windowPtr, ref rectangle);
        return rectangle;
    }
}
