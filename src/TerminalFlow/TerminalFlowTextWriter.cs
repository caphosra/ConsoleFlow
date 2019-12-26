using System;
using System.IO;

namespace TerminalFlow.Core
{
    public class CleanableTextWriter : IDisposable
    {
        private int cursorLeft = 0;
        private int cursorTop = 0;

        public CleanableTextWriter()
        {
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
        }

        public void Clean()
        {
            Console.SetCursorPosition(Console.CursorLeft, cursorTop);
        }

        public void Dispose() => Clean();
    }
}