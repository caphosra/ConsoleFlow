using System;
using System.Collections.Generic;

using TerminalFlow.Core;
using TerminalFlow.Native;

namespace TerminalFlow
{
    /// <summary>
    ///
    /// This class supports user to show ConsoleUIs with logic.
    ///
    /// </summary>
    public class ConsoleFlow : IDisposable
    {
        /// <summary>
        ///
        /// On Windows, enabling Virtual Terminal Processing is required.
        /// This boolean has whether it did or not.
        ///
        /// </summary>
        internal protected static bool isInitialized = false;

        /// <summary>
        ///
        /// After dispose this, does the user want to clean all?
        ///
        /// </summary>
        public bool CleanAll { get; set; }

        /// <summary>
        ///
        /// Childen UIs.
        ///
        /// </summary>
        private List<ConsoleUI> m_UIs =
            new List<ConsoleUI>();

        /// <summary>
        ///
        /// The positions of UIs which is included in m_UIs.
        ///
        /// </summary>
        private Dictionary<ConsoleUI, ConsoleVec2> m_UIPos =
            new Dictionary<ConsoleUI, ConsoleVec2>();

        /// <summary>
        ///
        /// The cursor position when displayed.
        ///
        /// </summary>
        private ConsoleVec2 m_StartPosition;

        public ConsoleFlow(params ConsoleUI[] uis)
        {
            foreach(var ui in uis)
            {
                Add(ui);
            }
        }

        /// <summary>
        ///
        /// Attach UI as child.
        ///
        /// </summary>
        public void Add(ConsoleUI ui)
        {
            m_UIs.Add(ui);
            ui.OnRepaint += OnReceiveRepaintEvent;
            ui.OnResize += OnReceiveResizeEvent;
        }

        /// <summary>
        ///
        /// Display all of the contents which are as children of this.
        ///
        /// </summary>
        public void Display()
        {
            Console.CursorVisible = false;

            if(!isInitialized)
            {
                if(Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    KernelWrapper.EnableVirtualTerminalProcessing();
                }
                isInitialized = true;
            }

            var currentPos = ConsoleVec2.Current;
            m_StartPosition = currentPos;

            foreach(var ui in m_UIs)
            {
                currentPos.Move();
                m_UIPos[ui] = currentPos;
                ui.Display();
                currentPos.Y += ui.Size.Height;
            }
        }

        /// <summary>
        ///
        /// Erase all after the cursor position.
        ///
        /// </summary>
        private void EraseAfter(ConsoleVec2 vec2)
        {
            vec2.Move();

            WordProcessor.ClearAfterCursor();
        }

        /// <summary>
        ///
        /// This function invoked when `sender` resizes.
        ///
        /// </summary>
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
                    EraseAfter(currentPos);
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

        /// <summary>
        ///
        /// This function invoked when `sender` repaints.
        ///
        /// </summary>
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

        /// <summary>
        ///
        /// Clean this item.
        ///
        /// </summary>
        public void Dispose()
        {
            if(CleanAll)
            {
                m_StartPosition.Move();
                WordProcessor.ClearAfterCursor();

                Console.CursorVisible = true;
            }
        }
    }
}