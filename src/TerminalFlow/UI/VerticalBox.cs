using System;
using System.Collections.Generic;

using TerminalFlow.Core;

namespace TerminalFlow
{
    public class VerticalBox : ConsoleUI
    {
        private List<ConsoleUI> m_UIs =
            new List<ConsoleUI>();

        public override ConsoleSize Size => m_Size;
        private ConsoleSize m_Size;

        public VerticalBox(params ConsoleUI[] children)
        {
            foreach(var child in children)
            {
                Add(child);
            }
        }

        public void Add(ConsoleUI ui)
        {
            m_UIs.Add(ui);
            ui.OnRepaint += OnReceiveRepaintEvent;
            ui.OnResize += OnReceiveResizeEvent;

            UpdateSize();
        }

        private void UpdateSize()
        {
            int maxWidth = 0;
            int height = 0;

            foreach(var ui in m_UIs)
            {
                maxWidth = Math.Max(maxWidth, ui.Size.Width);
                height += ui.Size.Height;
            }

            m_Size = new ConsoleSize(maxWidth, height);
        }

        public override void Display()
        {
            var currentPos = ConsoleVec2.Zero;
            var startPos = ConsoleVec2.Current;

            foreach(var ui in m_UIs)
            {
                var absolutePos = startPos + currentPos;
                absolutePos.Move();

                ui.Display();

                currentPos.Y += ui.Size.Height;
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