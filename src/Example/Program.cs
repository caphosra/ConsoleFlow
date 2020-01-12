using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ConsoleFlow;

namespace ConsoleFlow.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var examplesClass = new Examples();
            var methodsWithIndex = examplesClass
                .GetType()
                .GetMethods()
                .Where(method => new Regex(".*Example").IsMatch(method.Name))
                .Select((method, index) => (method, index))
                .ToArray();
            foreach (var method in methodsWithIndex)
            {
                Console.WriteLine($"{method.index} - {method.method.Name}");
            }
            try
            {
                Console.Write("Which do you want to run ? > ");

                var id = uint.Parse(Console.ReadLine());
                var method = methodsWithIndex[id].method;

                Console.Clear();
                Console.SetCursorPosition(0, 0);

                method.Invoke(examplesClass, null);
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);

                Console.WriteLine(e.ToString());
            }
            finally { }
        }
    }
}
