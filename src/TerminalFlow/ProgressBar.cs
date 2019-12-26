using System;
using System.Linq;
using System.Threading.Tasks;

using TerminalFlow.Core;

namespace TerminalFlow
{
    public class ProgressBar : ConsoleUI
    {
        public float Value
        {
            get => m_Value;
            set
            {
                m_Value = value;
                OnUIChanged?.Invoke(this);
            }
        }
        private float m_Value;

        private string m_Title;
        private int m_Length;

        public ProgressBar(string title = "", int length = 10)
        {
            m_Title = title;
            m_Length = length;
        }

        public override void Display()
        {
            if(m_Value < 0f || 1f < m_Value)
            {
                throw new ArgumentOutOfRangeException("The value of progress bar should be on 0-1.");
            }

            Console.Write(m_Title + "|");

            var progress = (int)Math.Floor(m_Value * m_Length);
            foreach(var count in Enumerable.Range(0, m_Length))
            {
                if(progress >= count && progress != 0)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }

            Console.WriteLine($"|{Math.Floor(m_Value * 100f)}%");
        }
    }
}
