using System;

using ConsoleFlow;

namespace ConsoleFlow.Example
{
    partial class Examples
    {
        public void ConsoleProgressExample()
        {
            var firstProgress = new ConsoleProgress(title: "ConsoleProgress", length: 50);
            var secondProgress = new SimpleProgress(title: "SimpleProgress", length: 50);

            var flow = new ConsoleFlow
            (
                firstProgress,
                secondProgress
            );

            flow.Display();

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    firstProgress.Value = Math.Clamp(firstProgress.Value + 0.1f, 0f, 1f);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    secondProgress.Value = Math.Clamp(secondProgress.Value + 0.1f, 0f, 1f);
                }
            }
        }
    }
}