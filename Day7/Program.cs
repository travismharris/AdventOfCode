using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var IpList = new List<Ip>();

            using (StreamReader sr = new StreamReader("C:\\AdventInput\\IpInput.txt"))
            {
                while (sr.Peek() > -1)
                {
                    IpList.Add(new Ip(sr.ReadLine()));
                }
            }

            Console.WriteLine("ABBA Count: " + IpList.Count(e => e.ConfirmedABBA==true));

            Console.WriteLine("ABA Count: " + IpList.Count(e => e.ConfirmedABA == true));



            Console.ReadKey();

        }
    }
}
