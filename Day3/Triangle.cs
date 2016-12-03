using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Triangle
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }
        public bool ValidTriangle { get; set; }

        public Triangle(int a, int b, int c)
        {
            Side1 = a;
            Side2 = b;
            Side3 = c;
            ValidTriangle = Validate();

        }

        public bool Validate()
        {
            if (Side1 + Side2 > Side3 && Side2 + Side3 > Side1 && Side3 + Side1 > Side2)
                return true;
            return false;
        }
    }
}
