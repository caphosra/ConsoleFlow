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

        public ConsoleColor BackgroundColor { get; private set; }
        public ConsoleColor TextColor { get; private set; }

        private string m_Text;

        public ConsoleText(string text)
        {
            m_Text = text;
            m_Size = new ConsoleSize(text.Length, 1);
        }

        public ConsoleText(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            m_Text = text;
            m_Size = new ConsoleSize(text.Length, 1);
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }

        public ConsoleText(out ConsoleText consoleText, string text)
        {
            m_Text = text;
            m_Size = new ConsoleSize(text.Length, 1);

            consoleText = this;
        }

        public ConsoleText(out ConsoleText consoleText, string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            m_Text = text;
            m_Size = new ConsoleSize(text.Length, 1);
            TextColor = textColor;
            BackgroundColor = backgroundColor;

            consoleText = this;
        }

        public override void Display()
        {
            Console.Write(m_Text);
        }
    }
}