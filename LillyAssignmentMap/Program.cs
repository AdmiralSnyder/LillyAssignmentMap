
using LillyAssignmentMap;
using System.Diagnostics;

var mapman = new MapMan();

// See https://aka.ms/new-console-template for more information
int zoomLevel = 1;
mapman.DisplayMap(zoomLevel);

#region attach mouse wheel

var hnd = Interop.GetStdHandle(StdHandles.STD_INPUT_HANDLE);
INPUT_RECORD[] buf = new INPUT_RECORD[1];


Interop.GetConsoleMode(hnd, out var mode);
mode &= ~ConsoleModes.ENABLE_QUICK_EDIT_MODE; //disable
mode |= ConsoleModes.ENABLE_WINDOW_INPUT; //enable (if you want)
mode |= ConsoleModes.ENABLE_MOUSE_INPUT; //enable
Interop.SetConsoleMode(hnd, mode);

//bool x = Interop.SetConsoleMode(inHandle, ConsoleModes.ENABLE_EXTENDED_FLAGS | ConsoleModes.ENABLE_WINDOW_INPUT | ConsoleModes.ENABLE_MOUSE_INPUT);


int pos = 0;

while (true)
{
    if (Interop.ReadConsoleInput(hnd, buf, (uint)buf.Length, out var num) /*&& num == 1*/)
    {
        if (buf[0].EventType == INPUT_RECORD_EventTypes.MOUSE_EVENT && buf[0].MouseEvent.dwEventFlags == MouseEventFlags.MOUSE_WHEELED)
        {
            bool up = (int)(((int)(buf[0].MouseEvent.dwButtonState)) & 0xFFFF0000) > 0;
            
            if (buf[0].MouseEvent.dwControlKeyState.HasFlag(ControlKeyState.SHIFT_PRESSED))
            {
                Console.SetWindowPosition(0, pos);
                pos += (up ? -1 : 1) * 5;
                if (pos < 0)
                {
                    pos = 0;
                }
            }
            else
            {
                zoomLevel += (up ? -1 : 1) * 1;
                if (zoomLevel < 0)
                {
                    zoomLevel = 0;
                }
                Console.Clear();
                mapman.DisplayMap(zoomLevel);
            }
        }
    }
}
#endregion








