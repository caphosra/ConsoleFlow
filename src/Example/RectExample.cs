using System;

using ConsoleFlow;

namespace ConsoleFlow.Example
{
    partial class Examples
    {
        public void RectExample()
        {
            var flow = new ConsoleFlow
            (
                new HBox
                (
                    new ConsoleRect(new ConsoleSize(6, 3), ConsoleColor.Red),
                    new ConsoleRect(new ConsoleSize(6, 3), ConsoleColor.Green)
                ),
                new HBox
                (
                    new ConsoleRect(new ConsoleSize(6, 3), ConsoleColor.Blue),
                    new ConsoleRect(new ConsoleSize(6, 3), ConsoleColor.Yellow)
                ),
                new ConsoleText("It's a Windows logo !")
            );

            flow.Display();

            Console.ReadKey(true);
        }
    }
}