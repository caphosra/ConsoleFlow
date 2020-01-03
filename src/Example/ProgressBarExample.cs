using System;

using TerminalFlow;

namespace TerminalFlow.Example
{
    partial class Examples
    {
        public void ProgressBarExample()
        {
            var firstProgress = new ConsoleProgressBar(title: "First", length: 100);
            var secondProgress = new ConsoleProgressBar(title: "Second", length: 100);

            var flow = new ConsoleFlow
            (
                firstProgress,
                secondProgress,
                new ConsoleText("Press [f] to increment First"),
                new ConsoleText("Press [s] to increment Second")
            );

            flow.Display();

            while(true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key == ConsoleKey.F)
                {
                    firstProgress.Value = Math.Clamp(firstProgress.Value + 0.1f, 0f, 1f);
                }
                else if (key == ConsoleKey.S)
                {
                    secondProgress.Value = Math.Clamp(secondProgress.Value + 0.1f, 0f, 1f);
                }
            }
        }
    }
}