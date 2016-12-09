using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen myScreen = new Screen(6, 50);

            using (StreamReader sr = new StreamReader("C:\\AdventInput\\ScreenINput.txt"))
            {
                while (sr.Peek() > -1)
                {
                    Console.Clear();
                    Command c = new Command(sr.ReadLine(), myScreen);
                    System.Threading.Thread.Sleep(50);
                }
            }
            Console.ReadKey();

            
            var b = 0;

            foreach (var a in myScreen.ScreenArray)
            {
                var list = a.ToList();
                b = b + list.Count(e => e);

            }
            Console.WriteLine("On Count = " + b);

            Console.ReadKey();
        }
    }
}
