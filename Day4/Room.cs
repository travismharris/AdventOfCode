using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Room
    {
        public bool Valid { get; set; }
        public string Name { get; set; }
        public int Sector { get; set; }
        public string ExtractedCheckSum { get; set; }
        public string CalculatedCheckSum { get; set; }

        public Room(string room)
        {
            //aaaaa-bbb-z-y-x-123[abxyz]
                //var a = room.ExtractName().ToCharArray();
                //Array.Sort(a);
                //Name = new string(a);
            Name = room.ExtractName();
            Sector = room.ExtractSector();
            ExtractedCheckSum = room.ExtractCheckSum();
            CalculatedCheckSum = CalculateCheckSum();
            Valid = CalculatedCheckSum == ExtractedCheckSum;
        }

        public string CalculateCheckSum()
        {
            var array = Name.ToCharArray();
            Array.Sort(array);

            string checkSum = "";

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var a in array)
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

            var sortedDict = from entry in dictionary orderby entry.Value descending select entry;

            foreach (KeyValuePair<char, int> entry in sortedDict)
            {
                if (checkSum.Length < 5)
                {
                    checkSum += entry.Key;
                }
                else
                    break;
            }

            return checkSum;
        }

        public override string ToString()
        {
            return
                $"Room Name: {Name} " +
                $"\nExtracted CheckSum: {ExtractedCheckSum} " +
                $"\nCalculated Checksum: {CalculatedCheckSum} " +
                $"\nRoom Sector: {Sector} " +
                $"\nRoom Valid: {Valid}";
        }

        public string Decrypt()
        {
            var array = Name.ToCharArray();
            string toReturn = "";

            foreach (var a in array)
            {
                toReturn +=(a.Rotate(Sector));
            }

            return toReturn;
        }

        
    }
}
