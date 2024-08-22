﻿using System.Windows.Interop;
using Linearstar.Windows.RawInput;
using Linearstar.Windows.RawInput.Native;
using static RawInput.Delegates;

namespace RawInput;

/// <summary>
/// Service responsible for working with input from HID and USB devices.
/// </summary>
public class RawHook : IInputService
{
    // More about WndProc in UWP: https://www.travelneil.com/wndproc-in-uwp.html

    /// <summary>
    /// Any custom WndProc handling code goes here...
    /// </summary>
    private const int WM_INPUT = 0x00FF;

    /// <summary>
    /// Raw input needs a window handle of an app.
    /// </summary>
    private IntPtr _windowHandle;

    /// <summary>
    /// List of pressed keys.
    /// </summary>
    private readonly List<KeyInfo> _pressedKeys;

    /// <summary>
    /// Key down event.
    /// </summary>
    public event KeyPress? KeyUp;

    /// <summary>
    /// Key up event.
    /// </summary>
    public event KeyPress? KeyDown;

    public RawHook()
    {
        _pressedKeys = new List<KeyInfo>();
    }

    /// <summary>
    /// Stops service.
    /// </summary>
    public void Stop()
    {
        _pressedKeys.Clear();
        // Register the keyboard device and you can register device which you need like mouse.
        RawInputDevice.UnregisterDevice(HidUsageAndPage.Keyboard);
    }

    /// <summary>
    /// Starts service and input capturing.
    /// </summary>
    public void Start()
    {
        // Register the keyboard device and you can register device which you need like mouse.
        RawInputDevice.RegisterDevice(HidUsageAndPage.Keyboard,
            RawInputDeviceFlags.InputSink | RawInputDeviceFlags.NoLegacy, _windowHandle);
    }

    /// <summary>
    /// Initialize service.
    /// </summary>
    /// <param name="windowHandle">Window hwnd.</param>
    public void Initialize(IntPtr windowHandle)
    {
        _windowHandle = windowHandle;

        Start();

        var source = HwndSource.FromHwnd(_windowHandle);
        source.AddHook(Hook);
    }

    private IntPtr Hook(int message, IntPtr lParam)
    {
        if (message == WM_INPUT)
        {
            InputProcess(lParam);
        }

        return IntPtr.Zero;
    }

    /// <summary>
    /// Processes input and invokes events.
    /// </summary>
    private void InputProcess(IntPtr lParam)
    {
        // Create an RawInputData from the handle stored in lParam.
        var data = RawInputData.FromHandle(lParam);

        var devicePath = data.Device?.DevicePath;

        if (string.IsNullOrEmpty(devicePath))
        {
            return;
        }

        if (data is RawInputKeyboardData keyboardData)
        {
            var keyboard = keyboardData.Keyboard;

            var keyInfo = new KeyInfo(keyboard.VirutalKey, devicePath);

            // TODO PrntScrn doesn't work!
            if (keyboard.VirutalKey == 255)
            {
                return;
            }

            if ((keyboard.Flags == RawKeyboardFlags.None || keyboard.Flags == RawKeyboardFlags.KeyE0 || keyboard.Flags == RawKeyboardFlags.KeyE1)
                && !_pressedKeys.Contains(keyInfo))
            {
                _pressedKeys.Add(keyInfo);
                KeyDown?.Invoke(new HookEventArgs(keyInfo));
            }

            if (keyboard.Flags == RawKeyboardFlags.Up
                || keyboard.Flags == (RawKeyboardFlags.Up | RawKeyboardFlags.KeyE0)
                || keyboard.Flags == (RawKeyboardFlags.Up | RawKeyboardFlags.KeyE1))
            {
                _pressedKeys.Remove(keyInfo);
                KeyUp?.Invoke(new HookEventArgs(keyInfo));
            }
        }
    }
}
