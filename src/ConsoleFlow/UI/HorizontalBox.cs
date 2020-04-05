using System;
using System.Collections.Generic;

using ConsoleFlow.Core;

namespace ConsoleFlow
{
    /// <summary>
    ///
    /// Layout children UIs horizontally.
    ///
    /// </summary>
    public class HorizontalBox : ConsoleUI
    {
        private List<ConsoleUI> m_UIs =
            new List<ConsoleUI>();

        public override ConsoleSize Size => m_Size;
        private ConsoleSize m_Size;

        public HorizontalBox(params ConsoleUI[] children)
        {
            foreach (var child in children)
            {
                Add(child);
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

            UpdateSize();
        }

        private void UpdateSize()
        {
            int maxHeight = 0;
            int width = 0;

            foreach (var ui in m_UIs)
            {
                maxHeight = Math.Max(maxHeight, ui.Size.Height);
                width += ui.Size.Width;
            }

            m_Size = new ConsoleSize(width, maxHeight);
        }

        public override void Display()
        {
            var currentPos = ConsoleVec2.Zero;
            var startPos = ConsoleVec2.Current;

            foreach (var ui in m_UIs)
            {
                var absolutePos = startPos + currentPos;
                absolutePos.Move();

                ui.Display();

                currentPos.X += ui.Size.Width;
            }
        }

        private void OnReceiveRepaintEvent(ConsoleUI ui)
        {
            InvokeRepaint();
        }

        private void OnReceiveResizeEvent(ConsoleUI ui)
        {
            UpdateSize();
            InvokeResize();
        }
    }
}