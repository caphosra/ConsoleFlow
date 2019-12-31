using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TerminalFlow.Core;

namespace TerminalFlow
{
    public class ConsoleProgressBar : ConsoleUI
    {
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

        public int Length => m_Length;
        private int m_Length;

        private string m_ProcessedText = "";

        private ConsoleSize m_Size = new ConsoleSize(0, 0);
        public override ConsoleSize Size => m_Size;

        public ConsoleProgressBar(string title = "", int length = 10)
        {
            m_Title = title;
            m_Length = length;

            m_ProcessedText = ProcessText();
            UpdateSize();
        }

        protected void UpdateSize()
        {
            m_Size = new ConsoleSize(WordProcessor.GetLength(m_ProcessedText), 1);
        }

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
