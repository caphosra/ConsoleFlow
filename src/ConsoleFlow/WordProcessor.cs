using System;
using System.Text;

namespace ConsoleFlow.Core
{
    /// <summary>
    ///
    /// This class supports to process the text of the UIs.
    ///
    /// </summary>
    public static class WordProcessor
    {
        /// <summary>
        ///
        /// Clean all behind the cursor by ANSI escape code.
        ///
        /// </summary>
        public static void ClearAfterCursor()
        {
            Console.Write("\u001b[0J");
        }

        /// <summary>
        ///
        /// Get the length of the text on UTF-8.
        ///
        /// </summary>
        public static int GetLength(string s)
        {
            return Encoding.UTF8.GetByteCount(s);
        }
    }
}