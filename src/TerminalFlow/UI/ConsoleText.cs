using System;
using TerminalFlow.Core;

namespace TerminalFlow
{
    /// <summary>
    ///
    /// The text on Console.
    /// Which works like a Label class on WindowsForms.
    ///
    /// </summary>
    public class ConsoleText : ConsoleUI
    {
        public override ConsoleSize Size => m_Size;
        private ConsoleSize m_Size;

        private string m_Text;

        public ConsoleText(string text)
        {
            m_Text = text;
            m_Size = new ConsoleSize(text.Length, 1);
        }

        public override void Display()
        {
            Console.Write(m_Text);
        }
    }
}