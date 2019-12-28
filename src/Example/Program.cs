using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using TerminalFlow;

namespace TerminalFlow.Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            using(var flow = new ConsoleFlow())
            {
                var firstProgress = new ConsoleProgressBar(title: "First", length: 100);
                flow.Add(firstProgress);

                var secondProgress = new ConsoleProgressBar(title: "Second", length: 100);
                flow.Add(secondProgress);

                flow.Display();

                for (int i = 0; i <= 50; i++)
                {
                    firstProgress.Value = i / 100f;
                    Task.Delay(100).Wait();
                }

                for (int i = 0; i <= 100; i++)
                {
                    secondProgress.Value = i / 100f;
                    Task.Delay(100).Wait();
                }

                for (int i = 50; i <= 100; i++)
                {
                    firstProgress.Value = i / 100f;
                    Task.Delay(100).Wait();
                }

                Console.ReadKey();
            }
        }
    }
}
