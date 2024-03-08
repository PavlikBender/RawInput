namespace RawInput;

/// <summary>
/// Delegate used in project.
/// </summary>
public class Delegates
{
    /// <summary>
    /// Delegate for WndProc.
    /// </summary>
    internal delegate IntPtr WndProcDelegate(IntPtr hwnd, uint message, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Defines delegate for KeyDown and KeyUp events.
    /// </summary>
    /// <param name="e">Event arguments</param>
    public delegate void KeyPress(HookEventArgs e);
}
