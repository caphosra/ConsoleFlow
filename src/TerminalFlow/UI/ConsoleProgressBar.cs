using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TerminalFlow.Core;

namespace TerminalFlow
{
    /// <summary>
    ///
    ///  A simple progress bar which works on Console.
    ///
    /// </summary>
    public class ConsoleProgressBar : ConsoleUI
    {
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
                m_Value = value;
                ContinueText();
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
                m_Title = value;
                ContinueText();
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

        /// <summary>
        ///
        /// Output text.
        ///
        /// </summary>
        private string m_ProcessedText = "";

        public override ConsoleSize Size => m_Size;
        private ConsoleSize m_Size = new ConsoleSize(0, 0);

        public ConsoleProgressBar(string title = "", int length = 10)
        {
            m_Title = title;
            m_Length = length;

            m_ProcessedText = ProcessText();
            UpdateSize();
        }

        public ConsoleProgressBar(out ConsoleProgressBar bar, string title = "", int length = 10)
        {
            m_Title = title;
            m_Length = length;

            m_ProcessedText = ProcessText();
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
            m_Size = new ConsoleSize(WordProcessor.GetLength(m_ProcessedText), 1);
        }

        /// <summary>
        ///
        /// Regenerate the text.
        ///
        /// </summary>
        /// <returns></returns>
        protected string ProcessText()
        {
            StringBuilder sb = new StringBuilder();

            if(m_Value < 0f || 1f < m_Value)
            {
                throw new ArgumentOutOfRangeException("The value of progress bar should be on 0-1.");
            }

            sb.Append(m_Title);
            sb.Append("|");

            var progress = (int)Math.Floor(m_Value * m_Length);
            foreach(var count in Enumerable.Range(0, m_Length))
            {
                if(progress >= count && progress != 0)
                {
                    sb.Append("*");
                }
                else
                {
                    sb.Append("-");
                }
            }

            sb.Append("|");
            sb.Append(Math.Floor(m_Value * 100f));
            sb.Append("%");

            return sb.ToString();
        }

        /// <summary>
        ///
        /// Generate the text and change the appearance.
        ///
        /// </summary>
        protected void ContinueText()
        {
            var newText = ProcessText();
            UpdateSize();

            if (newText != m_ProcessedText)
            {
                if (WordProcessor.GetLength(newText) != WordProcessor.GetLength(m_ProcessedText))
                {
                    m_ProcessedText = newText;
                    InvokeResize();
                }
                else
                {
                    m_ProcessedText = newText;
                    InvokeRepaint();
                }
            }
        }

        public override void Display()
        {
            Console.Write(m_ProcessedText);
        }
    }
}
