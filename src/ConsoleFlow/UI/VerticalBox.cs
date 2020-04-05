using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleFlow.Core;

namespace ConsoleFlow
{
    /// <summary>
    ///
    /// Layout children UIs horizontally.
    ///
    /// </summary>
    public class VBox : ConsoleUI
    {
        protected List<ConsoleUI> m_UIs =
            new List<ConsoleUI>();

        public override ConsoleSize Size => m_Size;
        protected ConsoleSize m_Size;

        public VBox(params ConsoleUI[] children)
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

        protected void UpdateSize()
        {
            var maxWidth = m_UIs.Max(ui => ui.Size.Width);
            var height = m_UIs.Sum(ui => ui.Size.Height);
            m_Size = new ConsoleSize(maxWidth, height);
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

                currentPos.Y += ui.Size.Height;
            }
        }

        protected virtual void OnReceiveRepaintEvent(ConsoleUI ui)
        {
            InvokeRepaint();
        }

        protected virtual void OnReceiveResizeEvent(ConsoleUI ui)
        {
            UpdateSize();
            InvokeResize();
        }
    }
}