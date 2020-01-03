using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using TerminalFlow;

namespace TerminalFlow.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var examplesClass = new Examples();
            var methods = examplesClass.GetType().GetMethods();
            methods = methods.Where(method => new Regex(".*Example").IsMatch(method.Name)).ToArray();
            int counter = 0;
            foreach (var method in methods)
            {
                Console.WriteLine($"{counter} - {method.Name}");
                counter++;
            }
            try
            {
                var id = uint.Parse(Console.ReadLine());
                var method = methods[id];

                Console.Clear();
                Console.SetCursorPosition(0, 0);

                method.Invoke(examplesClass, null);
            }
            finally { }
        }
    }
}
