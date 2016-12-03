using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> triangles = new List<Triangle>();

            using (StreamReader sr = new StreamReader("C:\\AdventInput\\Triangle.txt"))
            {
                while (sr.Peek() > -1)
                {
                    string input = "";
                    for (int i = 0; i < 3; i++)
                    {
                        input += sr.ReadLine();
                    }
                    
                    input = input.Trim();
                    while (input.Contains("  "))
                    {
                        input = input.Replace("  ", " ");
                    }
                    var stillInput = input.Split(' ');
                    Triangle t = new Triangle(int.Parse(stillInput[0]), int.Parse(stillInput[3]), int.Parse(stillInput[6]));
                    Triangle u = new Triangle(int.Parse(stillInput[1]), int.Parse(stillInput[4]), int.Parse(stillInput[7]));
                    Triangle v = new Triangle(int.Parse(stillInput[2]), int.Parse(stillInput[5]), int.Parse(stillInput[8]));
                    triangles.Add(t);
                    triangles.Add(u);
                    triangles.Add(v);
                }
            }

            Console.WriteLine("There are " + triangles.Count + " triangle inputs in the list.");
            var valid = triangles.Count(element => element.ValidTriangle == true);
            var invalid = triangles.Count(element => element.ValidTriangle == false);

            Console.WriteLine(invalid + " of the inputs are not valid, " + valid + " are valid.");
            Console.WriteLine("Press any key to exit\n");
            Console.ReadKey();
        }
    }


}
