using Linearstar.Windows.RawInput;

namespace RawInput;

/// <summary>
/// Registry of devices.
/// </summary>
public class DeviceRegistry : IDeviceRegistry
{
    /// <summary>
    /// Gets plugged devices paths
    /// </summary>
    /// <returns>List of devices paths.</returns>
    public List<string> GetPluggedDevicePaths()
    {
        // Get the devices that can be handled with Raw Input.
        return RawInputDevice.GetDevices().Where(d => !string.IsNullOrEmpty(d.DevicePath) && d is RawInputKeyboard).Select(d => d.DevicePath).ToList()!;
    }
}
