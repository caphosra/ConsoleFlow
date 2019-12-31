using System;

namespace TerminalFlow
{
    public class ConsoleVec2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static ConsoleVec2 Zero =>
            new ConsoleVec2(0, 0);

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

        public static ConsoleVec2 operator+(ConsoleVec2 a, ConsoleVec2 b)
        {
            return new ConsoleVec2(a.X + b.X, a.Y + b.Y);
        }
    }
}