using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            DoorBreaker breaker = new DoorBreaker("uqwqemis");

            Console.WriteLine(breaker.EntryCode);
            Console.ReadKey();
        }
    }
}
