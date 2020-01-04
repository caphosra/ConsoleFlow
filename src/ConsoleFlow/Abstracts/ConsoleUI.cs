#pragma warning disable CS0067

using System;

using ConsoleFlow;

namespace ConsoleFlow.Core
{
    /// <summary>
    ///
    /// The base class of UI.
    ///
    /// </summary>
    public abstract class ConsoleUI
    {
        /// <summary>
        ///
        /// The size of the component.
        ///
        /// </summary>
        public abstract ConsoleSize Size { get; }

        /// <summary>
        ///
        /// This event invoked when this component is resized.
        ///
        /// </summary>
        public event OnResizeEventHandler OnResize;

        /// <summary>
        ///
        /// This event invoked when this component is repainted.
        ///
        /// </summary>
        public event OnRepaintEventHandler OnRepaint;

        /// <summary>
        ///
        /// Paint this components.
        /// Setting the cursor to the begining of the components territory is required.
        ///
        /// </summary>
        public abstract void Display();

        /// <summary>
        ///
        /// Invoke OnResize event.
        ///
        /// </summary>
        protected void InvokeResize()
        {
            OnResize?.Invoke(this);
        }

        /// <summary>
        ///
        /// Invoke OnRepaint event.
        ///
        /// </summary>
        protected void InvokeRepaint()
        {
            OnRepaint?.Invoke(this);
        }
    }

    public delegate void OnResizeEventHandler(ConsoleUI ui);
    public delegate void OnRepaintEventHandler(ConsoleUI ui);
}
