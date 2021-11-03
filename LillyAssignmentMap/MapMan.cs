namespace LillyAssignmentMap;

internal class MapMan
{
    static char[,] map = new char[,] // dimensions defined by following data:
    {
            {'^','^','^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'^','^','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\''},
            {'^','^','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\''},
            {'^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
    };
    //map legend:
    // ^ = mountain
    // ' = grass
    // ~ = water
    // * = trees

    #region Map Drawing

    /// <summary>
    /// Colored output for the individual pieces
    /// </summary>
    /// <param name="item"></param>
    public static void DrawMapItem(char item)
    {
        switch (item)
        {
            case '^':
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(item);
                break;
            case '\'':
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item);
                break;
            case '~':
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(item);
                break;
            case '*':
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(item);
                break;
        }
    }

    /// <summary>
    /// Display the map
    /// </summary>
    public void DisplayMap() => DisplayMap(1);

    /// <summary>
    /// Display a scaled version of the map
    /// </summary>
    /// <param name="scale"></param>
    public void DisplayMap(int scale)
    {
        int cx = map.GetLength(1);
        int cy = map.GetLength(0);

        DrawHorzBorder();
        for (int x = 0; x < cx; x++)
        {
            for (int sy = 0; sy < scale; sy++)
            {
                DrawLine(x);
                Console.WriteLine();
            }
        }
        DrawHorzBorder();


        void DrawHorzBorder()
        {
            Console.Write('+');
            for (int i = 0; i < cy; i++)
            {
                for (int s = 0; s < scale; s++)
                {
                    Console.Write('-');
                }
            }
            Console.Write('+');
            Console.WriteLine();
        }

        void DrawLine(int x)
        {
            Console.Write('|');
            for (int y = 0; y < cy; y++)
            {
                for (int s = 0; s < scale; s++)
                {
                    DrawMapItem(map[y, x]);
                }
            }
            Console.Write('|');
        }
    }

    #endregion
}
