namespace RawInput;

/// <summary>
/// Service responsible for working with input from HID and USB devices.
/// </summary>
public interface IInputService
{
    /// <summary>
    /// Fires then keyboard key pressed down.
    /// </summary>
    event Delegates.KeyPress? KeyDown;

    /// <summary>
    /// Fires then keyboard key up.
    /// </summary>
    event Delegates.KeyPress? KeyUp;

    /// <summary>
    /// Initialize service.
    /// </summary>
    /// <param name="windowHandle">Window hwnd.</param>
    void Initialize(IntPtr windowHandle);

    /// <summary>
    /// Stops service.
    /// </summary>
    void Stop();

    /// <summary>
    /// Starts service and input capturing.
    /// </summary>
    void Start();
}