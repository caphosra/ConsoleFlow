using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleFlow.Core;

namespace ConsoleFlow
{
    /// <summary>
    ///
    ///  A simple progress bar which works on Console.
    ///
    /// </summary>
    public class ConsoleProgress : ConsoleUI
    {
        private const int TITLE_SPACE_WIDTH = 20;
        private const int DEFAULT_LENGTH = 50;
        private const ConsoleColor OK_COLOR = ConsoleColor.Green;

        /// <summary>
        ///
        /// The value of the progress bar.
        ///
        /// </summary>
        public float Value
        {
            get => m_Value;
            set
            {
                if(m_Value != value)
                {
                    m_Value = value;
                    InvokeRepaint();
                }
                else
                {
                    m_Value = value;
                }
            }
        }
        private float m_Value;

        /// <summary>
        ///
        /// The title of the progress bar.
        ///
        /// </summary>
        public string Title
        {
            get => m_Title;
            set
            {
                if (m_Title != value)
                {
                    m_Title = value;
                    InvokeRepaint();
                }
                else
                {
                    m_Title = value;
                }
            }
        }
        private string m_Title;

        /// <summary>
        ///
        /// The length of the value-shown part of the progress bar.
        ///
        /// </summary>
        public int Length => m_Length;
        private int m_Length;

        public override ConsoleSize Size => m_Size;
        private ConsoleSize m_Size = new ConsoleSize(0, 0);

        public ConsoleProgress(string title = "", int length = DEFAULT_LENGTH)
        {
            m_Title = title;
            m_Length = length;

            UpdateSize();
        }

        public ConsoleProgress(out ConsoleProgress bar, string title = "", int length = DEFAULT_LENGTH)
        {
            m_Title = title;
            m_Length = length;

            UpdateSize();

            bar = this;
        }

        /// <summary>
        ///
        /// Recalcutate the size.
        ///
        /// </summary>
        protected void UpdateSize()
        {

            //
            // Title |**********----------| 50%
            //
            int width = TITLE_SPACE_WIDTH + 1 + m_Length + 1 + 4;
            m_Size = new ConsoleSize(width, 1);
        }

        public override void Display()
        {
            var startPos = ConsoleVec2.Current;
            var relativePos = new ConsoleVec2(0, 0);
            (startPos + relativePos).Move();

            Console.Write(m_Title);

            relativePos += new ConsoleVec2(TITLE_SPACE_WIDTH, 0);
            (startPos + relativePos).Move();

            Console.Write("[");

            int progress = (int)Math.Floor(m_Length * m_Value);
            Console.BackgroundColor = OK_COLOR;
            for (int current = 0; current < m_Length; current++)
            {
                if(current == progress)
                {
                    Console.ResetColor();
                }

                if(current < progress)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.ResetColor();

            Console.Write("]");

            relativePos += new ConsoleVec2(1 + m_Length + 1, 0);
            (startPos + relativePos).Move();

            Console.Write($"{Math.Floor(m_Value * 100f)}%");
        }
    }
}
