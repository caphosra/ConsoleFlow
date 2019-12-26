using System;
using System.Collections.Generic;

using TerminalFlow.Core;
using TerminalFlow.Native;

namespace TerminalFlow
{
    public class ConsoleFlow : ConsoleUI, IDisposable    {
        internal protected static bool isInitialized = false;

        private List<ConsoleUI> m_UIs =
            new List<ConsoleUI>();

        public ConsoleFlow()
        {
            if(!isInitialized)
            {
                if(Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    KernelWrapper.EnableVirtualTerminalProcessing();
                }
                isInitialized = true;
            }
        }

        public void Add(ConsoleUI ui)
        {
            m_UIs.Add(ui);
            ui.OnUIChanged = OnReceiveUIChanged;
        }

        public override void Display()
        {
            Console.CursorVisible = false;

            foreach(var ui in m_UIs)
            {
                DisplayUI(ui);
            }
        }

        private void DisplayUI(ConsoleUI ui)
        {
            ui.StartPosition = (Console.CursorLeft, Console.CursorTop);
            ui.Display();
        }

        private void EraseAfter(ConsoleUI ui)
        {
            var pos = ui.StartPosition;
            Console.SetCursorPosition(pos.x, pos.y);

            ANSIEscapeCodeProcessor.ClearAfterCursor();
        }

        private void OnReceiveUIChanged(ConsoleUI sender)
        {
            bool willBeChanged = false;
            foreach(var ui in m_UIs)
            {
                if(ui == sender)
                {
                    willBeChanged = true;

                    EraseAfter(ui);
                }

                if(willBeChanged)
                {
                    DisplayUI(ui);
                }
            }

            if(!willBeChanged)
            {
                throw new ArgumentException("There is no content which is the same to 'sender'.");
            }
        }

        public void Dispose()
        {
            if(m_UIs.Count > 0)
            {
                EraseAfter(m_UIs[0]);
            }

            m_UIs = null;

            Console.CursorVisible = true;
        }
    }

    public delegate void OnUIChangedEventHandler(ConsoleUI sender);
}