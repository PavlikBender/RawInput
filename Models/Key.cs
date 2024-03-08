namespace RawInput;

/// <summary>
/// Key model.
/// </summary>
public class Key : IKey
{
    #region Mapping
    /// <summary>
    /// Mapping code to string.
    /// </summary>
    private static readonly Dictionary<uint, string> _mapping = new()
        {
            { 0x08 ,"← Backspace" },
            { 0x09 ,"Tab ↹" },
            { 0x0C ,"Clear" },
            { 0x0D ,"↵ Enter" },
            { 0x10 ,"⇧ Shift" },
            { 0x11 ,"Ctrl" },
            { 0x12 ,"Alt" },
            { 0x13 ,"Pause" },
            { 0x14 ,"Caps Lock" },
            { 0x15 ,"Kana mode" },
            { 0x16 ,"On" },
            { 0x17 ,"Junja mode" },
            { 0x18 ,"final mode" },
            { 0x19 ,"Hanja mode" },
            { 0x1A ,"Off" },
            { 0x1B ,"Esc" },
            { 0x1C ,"Convert" },
            { 0x1D ,"Nonconvert" },
            { 0x1E ,"Accept" },
            { 0x1F ,"Mode change" },
            { 0x20 ,"Space" },
            { 0x21 ,"Page Up" },
            { 0x22 ,"Page Down" },
            { 0x23 ,"End" },
            { 0x24 ,"Home" },
            { 0x25 ,"←" },
            { 0x26 ,"↑" },
            { 0x27 ,"→" },
            { 0x28 ,"↓" },
            { 0x29 ,"Select" },
            { 0x2A ,"Print" },
            { 0x2B ,"Execute" },
            { 0x2C ,"PrintScr" },
            { 0x2D ,"Ins" },
            { 0x2E ,"Del" },
            { 0x2F ,"Help" },
            { 0x30 ,"0" },
            { 0x31 ,"1" },
            { 0x32 ,"2" },
            { 0x33 ,"3" },
            { 0x34 ,"4" },
            { 0x35 ,"5" },
            { 0x36 ,"6" },
            { 0x37 ,"7" },
            { 0x38 ,"8" },
            { 0x39 ,"9" },
            { 0x41 ,"A" },
            { 0x42 ,"B" },
            { 0x43 ,"C" },
            { 0x44 ,"D" },
            { 0x45 ,"E" },
            { 0x46 ,"F" },
            { 0x47 ,"G" },
            { 0x48 ,"H" },
            { 0x49 ,"I" },
            { 0x4A ,"J" },
            { 0x4B ,"K" },
            { 0x4C ,"L" },
            { 0x4D ,"M" },
            { 0x4E ,"N" },
            { 0x4F ,"O" },
            { 0x50 ,"P" },
            { 0x51 ,"Q" },
            { 0x52 ,"R" },
            { 0x53 ,"S" },
            { 0x54 ,"T" },
            { 0x55 ,"U" },
            { 0x56 ,"V" },
            { 0x57 ,"W" },
            { 0x58 ,"X" },
            { 0x59 ,"Y" },
            { 0x5A ,"Z" },
            { 0x5B ,"⊞ Win" },
            { 0x5C ,"⊞ Win" },
            { 0x5D ,"≡" },
            { 0x5F ,"Sleep" },
            { 0x60 ,"NumPad 0" },
            { 0x61 ,"NumPad 1" },
            { 0x62 ,"NumPad 2" },
            { 0x63 ,"NumPad 3" },
            { 0x64 ,"NumPad 4" },
            { 0x65 ,"NumPad 5" },
            { 0x66 ,"NumPad 6" },
            { 0x67 ,"NumPad 7" },
            { 0x68 ,"NumPad 8" },
            { 0x69 ,"NumPad 9" },
            { 0x6A ,"NumPad *" },
            { 0x6B ,"NumPad +" },
            { 0x6C ,"Separator" },
            { 0x6D ,"NumPad -" },
            { 0x6E ,"NumPad ." },
            { 0x6F ,"NumPad /" },
            { 0x70 ,"F1" },
            { 0x71 ,"F2" },
            { 0x72 ,"F3" },
            { 0x73 ,"F4" },
            { 0x74 ,"F5" },
            { 0x75 ,"F6" },
            { 0x76 ,"F7" },
            { 0x77 ,"F8" },
            { 0x78 ,"F9" },
            { 0x79 ,"F10" },
            { 0x7A ,"F11" },
            { 0x7B ,"F12" },
            { 0x7C ,"F13" },
            { 0x7D ,"F14" },
            { 0x7E ,"F15" },
            { 0x7F ,"F16" },
            { 0x80 ,"F17" },
            { 0x81 ,"F18" },
            { 0x82 ,"F19" },
            { 0x83 ,"F20" },
            { 0x84 ,"F21" },
            { 0x85 ,"F22" },
            { 0x86 ,"F23" },
            { 0x87 ,"F24" },
            { 0x90 ,"Num Lock" },
            { 0x91 ,"Scroll Lock" },
            { 0xA0 ,"⇧L. Shift" },
            { 0xA1 ,"⇧R. Shift" },
            { 0xA2 ,"L. Ctrl" },
            { 0xA3 ,"R. Ctrl" },
            { 0xA4 ,"L. Alt" },
            { 0xA5 ,"R. Alt" },
            { 0xA6 ,"Back" },
            { 0xA7 ,"Forward" },
            { 0xA8 ,"Refresh" },
            { 0xA9 ,"Stop" },
            { 0xAA ,"Search" },
            { 0xAB ,"Favorites" },
            { 0xAC ,"Home" },
            { 0xAD ,"Volume Mute" },
            { 0xAE ,"Volume Down" },
            { 0xAF ,"Volume Up" },
            { 0xB0 ,"Next" },
            { 0xB1 ,"Previous" },
            { 0xB2 ,"Stop" },
            { 0xB3 ,"Play/Pause" },
            { 0xB4 ,"Mail" },
            { 0xB5 ,"Select Media" },
            { 0xB6 ,"Start App 1" },
            { 0xB7 ,"Start App 2" },
            { 0xBA ,";" },
            { 0xBB ,"+" },
            { 0xBC  ," ," },
            { 0xBD  ,"-" },
            { 0xBE  ,"." },
            { 0xBF ,"/" },
            { 0xC0 ,"`" },
            { 0xDB  ,"[" },
            { 0xDC  ,"\\" },
            { 0xDD  ,"]" },
            { 0xDE  ,"'" },
            { 0xE5 ,"Process" },
            { 0xF7 ,"CrSel" },
            { 0xF8 ,"ExSel" },
            { 0xF9 ,"Erase EOF" },
            { 0xFA ,"Play" },
            { 0xFB ,"Zoom" },
            { 0xFD ,"PA1" },
            { 0xFE ,"Clear" },
        };
    #endregion

    /// <summary>
    /// Code of key.
    /// </summary>
    public uint Code
    {
        get; 
        set;
    }

    public Key(uint code)
    {
        Code = code;
    }

    public Key(int code)
    {
        Code = Convert.ToUInt32(code);
    }

    public Key()
    {
    }

    /// <summary>
    /// Method transform key to user-readble view.
    /// </summary>
    /// <returns>Code of key translated to string.</returns>
    public override string ToString()
    {
        if (Code == 0)
            return string.Empty;

        if (_mapping.TryGetValue(Code, out var name))
            return name;

        return Code.ToString();
    }

    /// <summary>
    /// Compares two objects.
    /// </summary>
    /// <param name="obj">Second object.</param>
    /// <returns>true if objects equals, otherwise false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is Key key)
            return Code == key.Code;

        return base.Equals(obj);
    }

    /// <summary>
    /// Calculates hash code.
    /// </summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Code);
    }
}
