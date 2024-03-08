using System.Runtime.InteropServices;

namespace RawInput;

/// <summary>
/// Class of Windows API methods.
/// </summary>
internal static class WinAPI
{
    /// <summary>
    /// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
    /// More: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlongptra
    /// </summary>
    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    /// <summary>
    /// Passes message information to the specified window procedure.
    /// More: https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-callwindowproca
    /// </summary>
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
}
