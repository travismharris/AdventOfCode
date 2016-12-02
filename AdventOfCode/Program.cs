using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>()
            { "L1","L3","L5","L3","R1","L4","L5","R1","R3","L5","R1","L3",
              "L2","L3","R2","R2","L3","L3","R1","L2","R1","L3","L2","R4",
              "R2","L5","R4","L5","R4","L2","R3","L2","R4","R1","L5","L4",
              "R1","L2","R3","R1","R2","L4","R1","L2","R3","L2","L3","R5",
              "L192","R4","L5","R4","L1","R4","L4","R2","L5","R45","L2","L5",
              "R4","R5","L3","R5","R77","R2","R5","L5","R1","R4","L4","L4",
              "R2","L4","L1","R191","R1","L1","L2","L2","L4","L3","R1","L3",
              "R1","R5","R3","L1","L4","L2","L3","L1","L1","R5","L4","R1",
              "L3","R1","L2","R1","R4","R5","L4","L2","R4","R5","L1","L2",
              "R3","L4","R2","R2","R3","L2","L3","L5","R3","R1","L4","L3",
              "R4","R2","R2","R2","R1","L4","R4","R1","R2","R1","L2","L2",
              "R4","L1","L2","R3","L3","L5","L4","R4","L3","L1","L5","L3",
              "L5","R5","L5","L4","L2","R1","L2","L4","L2","L4","L1","R4",
              "R4","R5","R1","L4","R2","L4","L2","L4","R2","L4","L1","L2",
              "R1","R4","R3","R2","R2","R5","L1","L2"
            };

            Me travis = new Me();
            foreach (string move in input)
            {
                var thisMove = new Move(move);
                travis.Move(thisMove);
                Console.WriteLine(travis);
                //System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine("Final Position:  \nX = " + travis.X + "\tY = " + travis.Y + " Facing " + travis.Facing);
            StringBuilder sb1 = new StringBuilder();
            foreach (var c in travis.everyCoordTouched)
            {
                sb1.Append(c.ToString() + "\r\n");
            }
            var output = sb1.ToString();

            DirectoryInfo di = Directory.CreateDirectory("c:\\AdventOutput");

            var fileName = "c:\\AdventOutput\\advent.txt";

            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
            file.Write(output);
            file.Close();

            Console.WriteLine("Press any key");
            Console.ReadKey();

        }
    }
}
