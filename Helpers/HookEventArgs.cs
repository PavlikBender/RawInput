namespace RawInput;

/// <summary>
/// Event arguments for HookKeyPress delegate.
/// </summary>
public class HookEventArgs
{
    /// <summary>
    /// Pressed or released key.
    /// </summary>
    public IKey Key
    {
        get;
    }

    /// <summary>
    /// Device path.
    /// </summary>
    public string DevicePath
    {
        get;
    }

    public HookEventArgs(KeyInfo keyInfo)
    {
        Key = new Key(keyInfo.Key); 
        DevicePath = keyInfo.DevicePath;
    }
}