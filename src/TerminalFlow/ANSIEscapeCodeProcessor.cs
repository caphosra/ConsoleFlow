using System;

namespace TerminalFlow.Core
{
    public static class ANSIEscapeCodeProcessor
    {
        public static void ClearAfterCursor() => Console.Write("\u001b[0J");
    }
}