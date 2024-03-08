namespace RawInput;

/// <summary>
/// Information about key.
/// </summary>
public class KeyInfo
{
    /// <summary>
    /// Virtual key.
    /// </summary>
    public int Key
    {
        get;
    }

    /// <summary>
    /// Device path of key.
    /// </summary>
    public string DevicePath
    {
        get;
    }

    public KeyInfo(int key, string devicePath)
    {
        Key = key;
        DevicePath = devicePath;
    }

    /// <summary>
    /// Checks equality of two objects.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is KeyInfo keyInfo) 
        {
            return keyInfo.Key == Key && keyInfo.DevicePath == DevicePath;
        }

        return base.Equals(obj);
    }

    /// <summary>
    /// Calculates hash code.
    /// </summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Key, DevicePath);
    }
}
