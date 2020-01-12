using System;

using ConsoleFlow;

namespace ConsoleFlow.Example
{
    partial class Examples
    {
        public void ConsoleProgressExample()
        {
            var firstProgress = new ConsoleProgress(title: "First", length: 100);
            var secondProgress = new ConsoleProgress(title: "Second", length: 100);

            var flow = new ConsoleFlow
            (
                firstProgress,
                new ConsoleText(""),
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