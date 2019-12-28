using System;
using System.Collections.Generic;

using TerminalFlow.Core;
using TerminalFlow.Native;

namespace TerminalFlow
{
    public class ConsoleFlow : IDisposable
    {
        internal protected static bool isInitialized = false;

        private List<ConsoleUI> m_UIs =
            new List<ConsoleUI>();
        private Dictionary<ConsoleUI, ConsoleVec2> m_UIPos =
            new Dictionary<ConsoleUI, ConsoleVec2>();

        private ConsoleVec2 m_StartPosition;

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
            ui.OnRepaint += OnReceiveRepaintEvent;
            ui.OnResize += OnReceiveResizeEvent;
        }

        public void Display()
        {
            Console.CursorVisible = false;

            var currentPos = new ConsoleVec2(Console.CursorLeft, Console.CursorTop);
            m_StartPosition = currentPos;

            foreach(var ui in m_UIs)
            {
                currentPos.Move();
                m_UIPos[ui] = currentPos;
                ui.Display();
                currentPos.Y += ui.Size.Height;
            }
        }

        private void EraseAfter(ConsoleVec2 vec2)
        {
            vec2.Move();

            ANSIEscapeCodeProcessor.ClearAfterCursor();
        }

        private void OnReceiveResizeEvent(ConsoleUI sender)
        {
            var change = false;
            var currentPos = new ConsoleVec2(0, 0);

            foreach(var ui in m_UIs)
            {
                if(ui == sender)
                {
                    change = true;
                    currentPos = m_UIPos[ui];
                }

                if (change)
                {
                    currentPos.Move();
                    m_UIPos[ui] = currentPos;
                    ui.Display();
                    currentPos.Y += ui.Size.Height;
                }
            }
        }

        private void OnReceiveRepaintEvent(ConsoleUI sender)
        {
            if (m_UIPos.ContainsKey(sender))
            {
                var pos = m_UIPos[sender];
                pos.Move();
                sender.Display();
            }
            else
            {
                throw new ArgumentException("There is no sender.");
            }
        }

        public void Dispose()
        {
            m_StartPosition.Move();
            ANSIEscapeCodeProcessor.ClearAfterCursor();

            Console.CursorVisible = true;
        }
    }
}