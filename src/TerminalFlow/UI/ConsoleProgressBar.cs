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
                OnRepaint?.Invoke(this);
            }
        }
        private float m_Value;

        public string Title
        {
            get => m_Title;
            set
            {
                m_Title = value;
                OnResize?.Invoke(this);
            }
        }
        private string m_Title;

        public int Length => m_Length;
        private int m_Length;

        public override ConsoleSize Size
        {
            get
            {
                var titleWidth = Encoding.Unicode.GetByteCount(m_Title);
                return new ConsoleSize(titleWidth + m_Length + 2, 1);
            }
        }

        public override event OnRepaintEventHandler OnRepaint;
        public override event OnResizeEventHandler OnResize;

        public ConsoleProgressBar(string title = "", int length = 10)
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

            Console.Write($"|{Math.Floor(m_Value * 100f)}%");
        }
    }
}
