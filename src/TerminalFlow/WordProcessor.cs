using System;
using System.Text;

namespace TerminalFlow.Core
{
    public static class WordProcessor
    {
        public static void ClearAfterCursor()
        {
            Console.Write("\u001b[0J");
        }

        public static int GetLength(string s)
        {
            return Encoding.UTF8.GetByteCount(s);
        }
    }
}