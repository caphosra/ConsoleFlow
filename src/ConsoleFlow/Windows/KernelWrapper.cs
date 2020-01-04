using System;

using PInvoke;

namespace ConsoleFlow.Native
{
    /// <summary>
    ///
    /// Kernel wrapper, which does not implement everything.
    ///
    /// </summary>
    internal static class KernelWrapper
    {
        /// <summary>
        ///
        /// Enable the virtual terminal processing.
        ///
        /// </summary>
        public static void EnableVirtualTerminalProcessing()
        {
            var hStdoutHandle = Kernel32.GetStdHandle(Kernel32.StdHandle.STD_OUTPUT_HANDLE);

            if (!Kernel32.GetConsoleMode(hStdoutHandle, out Kernel32.ConsoleBufferModes lpMode))
            {
                throw new SystemException("We could not get output console mode");
            }

            lpMode |= Kernel32.ConsoleBufferModes.ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            lpMode |= Kernel32.ConsoleBufferModes.DISABLE_NEWLINE_AUTO_RETURN;

            if (!Kernel32.SetConsoleMode(hStdoutHandle, lpMode))
            {
                throw new SystemException("We could not set output console mode");
            }
        }
    }
}