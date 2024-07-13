namespace RawInput;

/// <summary>
/// Interface of key.
/// </summary>
public interface IKey
{
    /// <summary>
    /// Code of key.
    /// </summary>
    uint Code
    {
        get;
        set;
    }

    /// <summary>
    /// Name of key.
    /// </summary>
    string Name
    {
        get;
    }
}