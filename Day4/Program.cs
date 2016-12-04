using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var printOutput = true;
            List<Room> rooms = new List<Room>();

            using (StreamReader sr = new StreamReader("c:\\AdventInput\\Rooms.txt"))
            {
                while (sr.Peek() > -1)
                {
                    rooms.Add(new Room(sr.ReadLine()));
                }
            }
            Console.WriteLine("Count: " + rooms.Count());
            var result = rooms.Where(e => e.Valid == true).ToList();
            var badRecords = rooms.Where(e => e.Valid == false).ToList();

            Console.WriteLine("Count valid: " + result.Count() + "\nCount Not Valid: " + badRecords.Count);
            Console.WriteLine(result.Sum(e=>e.Sector));

            if (printOutput)
            {
                foreach (var a in result)
                {
                    if (a.Decrypt().Contains("north"))
                    {
                        Console.WriteLine(a.Sector + " name= " + a.Decrypt()); //.Contains("north"));
                        // Console.ReadKey();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
