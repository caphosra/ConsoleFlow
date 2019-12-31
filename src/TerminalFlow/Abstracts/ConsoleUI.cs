#pragma warning disable CS0067

using System;

using TerminalFlow;

namespace TerminalFlow.Core
{
    public abstract class ConsoleUI
    {
        public abstract ConsoleSize Size { get; }

        public event OnResizeEventHandler OnResize;
        public event OnRepaintEventHandler OnRepaint;

        public abstract void Display();

        protected void InvokeResize()
        {
            OnResize?.Invoke(this);
        }

        protected void InvokeRepaint()
        {
            OnRepaint?.Invoke(this);
        }
    }

    public delegate void OnResizeEventHandler(ConsoleUI ui);
    public delegate void OnRepaintEventHandler(ConsoleUI ui);
}