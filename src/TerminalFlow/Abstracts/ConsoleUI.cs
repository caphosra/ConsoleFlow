#pragma warning disable CS0067

using System;

using TerminalFlow;

namespace TerminalFlow.Core
{
    public abstract class ConsoleUI
    {
        public abstract ConsoleSize Size { get; }

        public virtual event OnResizeEventHandler OnResize;
        public virtual event OnRepaintEventHandler OnRepaint;

        public abstract void Display();
    }

    public delegate void OnResizeEventHandler(ConsoleUI ui);
    public delegate void OnRepaintEventHandler(ConsoleUI ui);
}