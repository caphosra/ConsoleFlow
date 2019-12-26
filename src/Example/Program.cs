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

            var console = new ConsoleFlow();

            var firstProgress = new ProgressBar(title: "First", length: 100);
            console.Add(firstProgress);

            var secondProgress = new ProgressBar(title: "Second", length: 100);
            console.Add(secondProgress);

            console.Display();

            var finishedTaskCount = 0f;
            while(finishedTaskCount <= 500f)
            {
                if(finishedTaskCount <= 250f) firstProgress.Value = finishedTaskCount / 250f;
                else secondProgress.Value = (finishedTaskCount - 250f) / 250f;
                finishedTaskCount++;

                Task.Delay(10).Wait();
            }
        }
    }
}
