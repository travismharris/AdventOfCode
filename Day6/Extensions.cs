using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public static class Extensions
    {
        public static char MostFrequentChar(this string toSort)
        {
            var dictionary = new Dictionary<char, int>();

            foreach (var a in toSort)
            {
                if (dictionary.ContainsKey(a))
                {
                    dictionary[a] += 1;
                }
                else
                {
                    dictionary.Add(a, 1);
                }
            }

            var max = dictionary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            return max;

        }

        public static char LeastFrequentChar(this string toSort)
        {
            var dictionary = new Dictionary<char, int>();

            foreach (var a in toSort)
            {
                if (dictionary.ContainsKey(a))
                {
                    dictionary[a] += 1;
                }
                else
                {
                    dictionary.Add(a, 1);
                }
            }

            var min = dictionary.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            return min;

        }
    }

}
