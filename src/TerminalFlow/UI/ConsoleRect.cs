using System;
using System.Linq;

using TerminalFlow.Core;

namespace TerminalFlow
{
    /// <summary>
    ///
    /// The colored rectangle on Console.
    ///
    /// </summary>
    public class ConsoleRect : ConsoleUI
    {
        public override ConsoleSize Size => m_Size;
        private ConsoleSize m_Size;

        /// <summary>
        ///
        /// The color which is painted.
        ///
        /// </summary>
        public ConsoleColor Color
        {
            get => m_Color;
            set
            {
                m_Color = value;
                InvokeRepaint();
            }
        }
        private ConsoleColor m_Color;

        public ConsoleRect(ConsoleSize size, ConsoleColor color)
        {
            m_Size = size;
            m_Color = color;
        }

        /// <summary>
        ///
        /// Chnage the size of the rectangle.
        ///
        /// </summary>
        public void ChangeSize(ConsoleSize size)
        {
            m_Size = size;
            InvokeResize();
        }

        public override void Display()
        {
            var startPos = ConsoleVec2.Current;

            Console.BackgroundColor = Color;

            for(var y = 0; y < m_Size.Height; y++)
            {
                var currentPos = startPos + new ConsoleVec2(0, y);
                currentPos.Move();
                Console.Write(string.Concat(Enumerable.Repeat(" ", m_Size.Width)));
            }

            Console.ResetColor();
        }
    }
}