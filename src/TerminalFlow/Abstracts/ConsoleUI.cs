using System;

using TerminalFlow;

namespace TerminalFlow.Core
{
    public abstract class ConsoleUI
    {
        public (int x, int y) StartPosition { get; internal set; } = (-1, -1);

        public OnUIChangedEventHandler OnUIChanged { get; set; }

        public abstract void Display();
    }
}