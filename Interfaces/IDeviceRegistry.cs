namespace RawInput;

/// <summary>
/// Registry of devices.
/// </summary>
public interface IDeviceRegistry
{
    /// <summary>
    /// Gets plugged devices paths
    /// </summary>
    /// <returns>List of devices paths.</returns>
    List<string> GetPluggedDevicePaths();
}