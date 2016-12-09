using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message();

            using (StreamReader sr = new StreamReader("C:\\AdventInput\\Columnar.txt"))
            {
                while (sr.Peek() > -1)
                {
                    message.MessageList.Add(sr.ReadLine());
                }
            }

            var turn = message.TurnList(8);

            var santaMessage = "";
            foreach (var a in turn)
            {
                santaMessage += a.MostFrequentChar();
            }

            Console.WriteLine("Santa's Message is:  " + santaMessage);

            santaMessage = "";
            foreach (var a in turn)
            {
                santaMessage += a.LeastFrequentChar();
            }

            Console.WriteLine("Santa's *real* message is:  " + santaMessage);

            Console.ReadLine();



        }
    }
}
