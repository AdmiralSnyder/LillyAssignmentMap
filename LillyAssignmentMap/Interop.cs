﻿using System.Runtime.InteropServices;

namespace LillyAssignmentMap;

internal static class Interop
{

    // P/Invoke is the means to get access to unmanaged dlls, basically.
    // bing for "PInvoke ReadConsoleInput" to get these definitions

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "ReadConsoleInputW")]
    public static extern bool ReadConsoleInput(
    IntPtr hConsoleInput,
    [Out] INPUT_RECORD[] lpBuffer,
    uint nLength,
    out uint lpNumberOfEventsRead);






    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetConsoleWindow();
    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool FreeConsole();


    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out ConsoleModes lpMode);


    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, ConsoleModes dwMode);


    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(StdHandles nStdHandle);
}

public enum StdHandles: int
{
    STD_OUTPUT_HANDLE = -11,
    STD_INPUT_HANDLE = -10,
    STD_ERROR_HANDLE = -12,
}

[StructLayout(LayoutKind.Explicit)]
public struct INPUT_RECORD
{
    [FieldOffset(0)]
    public INPUT_RECORD_EventTypes EventType;
    [FieldOffset(4)]
    public KEY_EVENT_RECORD KeyEvent;
    [FieldOffset(4)]
    public MOUSE_EVENT_RECORD MouseEvent;
    [FieldOffset(4)]
    public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
    [FieldOffset(4)]
    public MENU_EVENT_RECORD MenuEvent;
    [FieldOffset(4)]
    public FOCUS_EVENT_RECORD FocusEvent;
};

public enum INPUT_RECORD_EventTypes : ushort
{
    KEY_EVENT = 0x1,
    MOUSE_EVENT = 0x2,
    WINDOW_BUFFER_SIZE_EVENT = 0x4,
    MENU_EVENT = 0x8,
    FOCUS_EVENT = 0x10,
}

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct KEY_EVENT_RECORD
{
    [FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
    public bool bKeyDown;
    [FieldOffset(4), MarshalAs(UnmanagedType.U2)]
    public ushort wRepeatCount;
    [FieldOffset(6), MarshalAs(UnmanagedType.U2)]
    public VirtualKeys wVirtualKeyCode;
    [FieldOffset(8), MarshalAs(UnmanagedType.U2)]
    public ushort wVirtualScanCode;
    [FieldOffset(10)]
    public char UnicodeChar;
    [FieldOffset(12), MarshalAs(UnmanagedType.U4)]
    public ControlKeyState dwControlKeyState;
}

[StructLayout(LayoutKind.Sequential)]
public struct MOUSE_EVENT_RECORD
{
    public COORD dwMousePosition;
    public MouseButtonState dwButtonState;
    public ControlKeyState dwControlKeyState;
    public MouseEventFlags dwEventFlags;
}

[Flags]
public enum MouseButtonState : int
{
    FROM_LEFT_1ST_BUTTON_PRESSED = 0x1,
    RIGHTMOST_BUTTON_PRESSED = 0x2,
    FROM_LEFT_2ND_BUTTON_PRESSED = 0x4,
    FROM_LEFT_3RD_BUTTON_PRESSED = 0x8,
    FROM_LEFT_4TH_BUTTON_PRESSED = 0x10
}

[Flags]
public enum ControlKeyState
{
    RIGHT_ALT_PRESSED = 0x1,
    LEFT_ALT_PRESSED = 0x2,
    RIGHT_CTRL_PRESSED = 0x4,
    LEFT_CTRL_PRESSED = 0x8,
    SHIFT_PRESSED = 0x10,
    NUMLOCK_ON = 0x20,
    SCROLLLOCK_ON = 0x40,
    CAPSLOCK_ON = 0x80,
    ENHANCED_KEY = 0x100
}

[Flags]
public enum MouseEventFlags
{
    MOUSE_MOVED = 0x1,
    DOUBLE_CLICK = 0x2,
    /// <summary>
    /// The vertical mouse wheel was moved.<br/>
    /// If the high word of the dwButtonState member contains a positive value, the wheel was rotated forward, away from the user. Otherwise, the wheel was rotated backward, toward the user.
    /// </summary>
    MOUSE_WHEELED = 0x4,
    MOUSE_HWHEELED = 0x8
}

public struct WINDOW_BUFFER_SIZE_RECORD
{
    public COORD dwSize;

    public WINDOW_BUFFER_SIZE_RECORD(short x, short y)
    {
        this.dwSize = new COORD(x, y);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct COORD
{
    public short X;
    public short Y;

    public COORD(short X, short Y)
    {
        this.X = X;
        this.Y = Y;
    }
};

[StructLayout(LayoutKind.Sequential)]
public struct MENU_EVENT_RECORD
{
    public uint dwCommandId;
}

[StructLayout(LayoutKind.Sequential)]
public struct FOCUS_EVENT_RECORD
{
    public uint bSetFocus;
}

/// <summary>
/// Enumeration for virtual keys.
/// </summary>
public enum VirtualKeys : ushort
{
    LeftButton = 0x01,
    RightButton = 0x02,
    Cancel = 0x03,
    MiddleButton = 0x04,
    ExtraButton1 = 0x05,
    ExtraButton2 = 0x06,
    Back = 0x08,
    Tab = 0x09,
    Clear = 0x0C,
    Return = 0x0D,
    Shift = 0x10,
    Control = 0x11,
    /// <summary></summary>
    Menu = 0x12,
    /// <summary></summary>
    Pause = 0x13,
    /// <summary></summary>
    CapsLock = 0x14,
    /// <summary></summary>
    Kana = 0x15,
    /// <summary></summary>
    Hangeul = 0x15,
    /// <summary></summary>
    Hangul = 0x15,
    /// <summary></summary>
    Junja = 0x17,
    /// <summary></summary>
    Final = 0x18,
    /// <summary></summary>
    Hanja = 0x19,
    /// <summary></summary>
    Kanji = 0x19,
    /// <summary></summary>
    Escape = 0x1B,
    /// <summary></summary>
    Convert = 0x1C,
    /// <summary></summary>
    NonConvert = 0x1D,
    /// <summary></summary>
    Accept = 0x1E,
    /// <summary></summary>
    ModeChange = 0x1F,
    /// <summary></summary>
    Space = 0x20,
    /// <summary></summary>
    Prior = 0x21,
    /// <summary></summary>
    Next = 0x22,
    /// <summary></summary>
    End = 0x23,
    /// <summary></summary>
    Home = 0x24,
    /// <summary></summary>
    Left = 0x25,
    /// <summary></summary>
    Up = 0x26,
    /// <summary></summary>
    Right = 0x27,
    /// <summary></summary>
    Down = 0x28,
    /// <summary></summary>
    Select = 0x29,
    /// <summary></summary>
    Print = 0x2A,
    /// <summary></summary>
    Execute = 0x2B,
    /// <summary></summary>
    Snapshot = 0x2C,
    /// <summary></summary>
    Insert = 0x2D,
    /// <summary></summary>
    Delete = 0x2E,
    /// <summary></summary>
    Help = 0x2F,
    /// <summary></summary>
    N0 = 0x30,
    /// <summary></summary>
    N1 = 0x31,
    /// <summary></summary>
    N2 = 0x32,
    /// <summary></summary>
    N3 = 0x33,
    /// <summary></summary>
    N4 = 0x34,
    /// <summary></summary>
    N5 = 0x35,
    /// <summary></summary>
    N6 = 0x36,
    /// <summary></summary>
    N7 = 0x37,
    /// <summary></summary>
    N8 = 0x38,
    /// <summary></summary>
    N9 = 0x39,
    /// <summary></summary>
    A = 0x41,
    /// <summary></summary>
    B = 0x42,
    /// <summary></summary>
    C = 0x43,
    /// <summary></summary>
    D = 0x44,
    /// <summary></summary>
    E = 0x45,
    /// <summary></summary>
    F = 0x46,
    /// <summary></summary>
    G = 0x47,
    /// <summary></summary>
    H = 0x48,
    /// <summary></summary>
    I = 0x49,
    /// <summary></summary>
    J = 0x4A,
    /// <summary></summary>
    K = 0x4B,
    /// <summary></summary>
    L = 0x4C,
    /// <summary></summary>
    M = 0x4D,
    /// <summary></summary>
    N = 0x4E,
    /// <summary></summary>
    O = 0x4F,
    /// <summary></summary>
    P = 0x50,
    /// <summary></summary>
    Q = 0x51,
    /// <summary></summary>
    R = 0x52,
    /// <summary></summary>
    S = 0x53,
    /// <summary></summary>
    T = 0x54,
    /// <summary></summary>
    U = 0x55,
    /// <summary></summary>
    V = 0x56,
    /// <summary></summary>
    W = 0x57,
    /// <summary></summary>
    X = 0x58,
    /// <summary></summary>
    Y = 0x59,
    /// <summary></summary>
    Z = 0x5A,
    /// <summary></summary>
    LeftWindows = 0x5B,
    /// <summary></summary>
    RightWindows = 0x5C,
    /// <summary></summary>
    Application = 0x5D,
    /// <summary></summary>
    Sleep = 0x5F,
    /// <summary></summary>
    Numpad0 = 0x60,
    /// <summary></summary>
    Numpad1 = 0x61,
    /// <summary></summary>
    Numpad2 = 0x62,
    /// <summary></summary>
    Numpad3 = 0x63,
    /// <summary></summary>
    Numpad4 = 0x64,
    /// <summary></summary>
    Numpad5 = 0x65,
    /// <summary></summary>
    Numpad6 = 0x66,
    /// <summary></summary>
    Numpad7 = 0x67,
    /// <summary></summary>
    Numpad8 = 0x68,
    /// <summary></summary>
    Numpad9 = 0x69,
    /// <summary></summary>
    Multiply = 0x6A,
    /// <summary></summary>
    Add = 0x6B,
    /// <summary></summary>
    Separator = 0x6C,
    /// <summary></summary>
    Subtract = 0x6D,
    /// <summary></summary>
    Decimal = 0x6E,
    /// <summary></summary>
    Divide = 0x6F,
    /// <summary></summary>
    F1 = 0x70,
    /// <summary></summary>
    F2 = 0x71,
    /// <summary></summary>
    F3 = 0x72,
    /// <summary></summary>
    F4 = 0x73,
    /// <summary></summary>
    F5 = 0x74,
    /// <summary></summary>
    F6 = 0x75,
    /// <summary></summary>
    F7 = 0x76,
    /// <summary></summary>
    F8 = 0x77,
    /// <summary></summary>
    F9 = 0x78,
    /// <summary></summary>
    F10 = 0x79,
    /// <summary></summary>
    F11 = 0x7A,
    /// <summary></summary>
    F12 = 0x7B,
    /// <summary></summary>
    F13 = 0x7C,
    /// <summary></summary>
    F14 = 0x7D,
    /// <summary></summary>
    F15 = 0x7E,
    /// <summary></summary>
    F16 = 0x7F,
    /// <summary></summary>
    F17 = 0x80,
    /// <summary></summary>
    F18 = 0x81,
    /// <summary></summary>
    F19 = 0x82,
    /// <summary></summary>
    F20 = 0x83,
    /// <summary></summary>
    F21 = 0x84,
    /// <summary></summary>
    F22 = 0x85,
    /// <summary></summary>
    F23 = 0x86,
    /// <summary></summary>
    F24 = 0x87,
    /// <summary></summary>
    NumLock = 0x90,
    /// <summary></summary>
    ScrollLock = 0x91,
    /// <summary></summary>
    NEC_Equal = 0x92,
    /// <summary></summary>
    Fujitsu_Jisho = 0x92,
    /// <summary></summary>
    Fujitsu_Masshou = 0x93,
    /// <summary></summary>
    Fujitsu_Touroku = 0x94,
    /// <summary></summary>
    Fujitsu_Loya = 0x95,
    /// <summary></summary>
    Fujitsu_Roya = 0x96,
    /// <summary></summary>
    LeftShift = 0xA0,
    /// <summary></summary>
    RightShift = 0xA1,
    /// <summary></summary>
    LeftControl = 0xA2,
    /// <summary></summary>
    RightControl = 0xA3,
    /// <summary></summary>
    LeftMenu = 0xA4,
    /// <summary></summary>
    RightMenu = 0xA5,
    /// <summary></summary>
    BrowserBack = 0xA6,
    /// <summary></summary>
    BrowserForward = 0xA7,
    /// <summary></summary>
    BrowserRefresh = 0xA8,
    /// <summary></summary>
    BrowserStop = 0xA9,
    /// <summary></summary>
    BrowserSearch = 0xAA,
    /// <summary></summary>
    BrowserFavorites = 0xAB,
    /// <summary></summary>
    BrowserHome = 0xAC,
    /// <summary></summary>
    VolumeMute = 0xAD,
    /// <summary></summary>
    VolumeDown = 0xAE,
    /// <summary></summary>
    VolumeUp = 0xAF,
    /// <summary></summary>
    MediaNextTrack = 0xB0,
    /// <summary></summary>
    MediaPrevTrack = 0xB1,
    /// <summary></summary>
    MediaStop = 0xB2,
    /// <summary></summary>
    MediaPlayPause = 0xB3,
    /// <summary></summary>
    LaunchMail = 0xB4,
    /// <summary></summary>
    LaunchMediaSelect = 0xB5,
    /// <summary></summary>
    LaunchApplication1 = 0xB6,
    /// <summary></summary>
    LaunchApplication2 = 0xB7,
    /// <summary></summary>
    OEM1 = 0xBA,
    /// <summary></summary>
    OEMPlus = 0xBB,
    /// <summary></summary>
    OEMComma = 0xBC,
    /// <summary></summary>
    OEMMinus = 0xBD,
    /// <summary></summary>
    OEMPeriod = 0xBE,
    /// <summary></summary>
    OEM2 = 0xBF,
    /// <summary></summary>
    OEM3 = 0xC0,
    /// <summary></summary>
    OEM4 = 0xDB,
    /// <summary></summary>
    OEM5 = 0xDC,
    /// <summary></summary>
    OEM6 = 0xDD,
    /// <summary></summary>
    OEM7 = 0xDE,
    /// <summary></summary>
    OEM8 = 0xDF,
    /// <summary></summary>
    OEMAX = 0xE1,
    /// <summary></summary>
    OEM102 = 0xE2,
    /// <summary></summary>
    ICOHelp = 0xE3,
    /// <summary></summary>
    ICO00 = 0xE4,
    /// <summary></summary>
    ProcessKey = 0xE5,
    /// <summary></summary>
    ICOClear = 0xE6,
    /// <summary></summary>
    Packet = 0xE7,
    /// <summary></summary>
    OEMReset = 0xE9,
    /// <summary></summary>
    OEMJump = 0xEA,
    /// <summary></summary>
    OEMPA1 = 0xEB,
    /// <summary></summary>
    OEMPA2 = 0xEC,
    /// <summary></summary>
    OEMPA3 = 0xED,
    /// <summary></summary>
    OEMWSCtrl = 0xEE,
    /// <summary></summary>
    OEMCUSel = 0xEF,
    /// <summary></summary>
    OEMATTN = 0xF0,
    /// <summary></summary>
    OEMFinish = 0xF1,
    /// <summary></summary>
    OEMCopy = 0xF2,
    /// <summary></summary>
    OEMAuto = 0xF3,
    /// <summary></summary>
    OEMENLW = 0xF4,
    /// <summary></summary>
    OEMBackTab = 0xF5,
    /// <summary></summary>
    ATTN = 0xF6,
    /// <summary></summary>
    CRSel = 0xF7,
    /// <summary></summary>
    EXSel = 0xF8,
    /// <summary></summary>
    EREOF = 0xF9,
    /// <summary></summary>
    Play = 0xFA,
    /// <summary></summary>
    Zoom = 0xFB,
    /// <summary></summary>
    Noname = 0xFC,
    /// <summary></summary>
    PA1 = 0xFD,
    /// <summary></summary>
    OEMClear = 0xFE
}

[Flags]
internal enum ConsoleModes : uint
{
    ENABLE_PROCESSED_INPUT = 0x0001,
    ENABLE_LINE_INPUT = 0x0002,
    ENABLE_ECHO_INPUT = 0x0004,
    ENABLE_WINDOW_INPUT = 0x0008,
    ENABLE_MOUSE_INPUT = 0x0010,
    ENABLE_INSERT_MODE = 0x0020,
    ENABLE_QUICK_EDIT_MODE = 0x0040,
    ENABLE_EXTENDED_FLAGS = 0x0080,
    ENABLE_AUTO_POSITION = 0x0100,

    ENABLE_PROCESSED_OUTPUT = 0x0001,
    ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,
    ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,
    DISABLE_NEWLINE_AUTO_RETURN = 0x0008,
    ENABLE_LVB_GRID_WORLDWIDE = 0x0010
}



