using System;

namespace TerminalFlow
{
    public struct ConsoleVec2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ConsoleVec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move()
        {
            Console.SetCursorPosition(X, Y);
        }

        public static ConsoleVec2 Current =>
            new ConsoleVec2(Console.CursorLeft, Console.CursorTop);
    }
}