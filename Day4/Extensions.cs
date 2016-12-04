using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public static class Extensions
    {
        //aaaaa-bbb-z-y-x-123[abxyz]

        public static string ExtractName(this string s)
        {
            s = s.Substring(0, s.IndexOf("["));
            var array = s.ToCharArray();
            string name = "";
            foreach (var a in array)
            {
                if (Char.IsLetter(a))
                {
                    name += a;
                }
            }
            return name;
        }

        public static int ExtractSector(this string s)
        {
            var array = s.ToCharArray();
            string sectorString = "";
            foreach(var a in array)
            {
                if (Char.IsDigit(a))
                {
                    sectorString += a;
                }
            }
            return int.Parse(sectorString);
        }

        public static string ExtractCheckSum(this string s)
        {
            return s.Substring(s.IndexOf("[") + 1, ((s.IndexOf("]")-1) - s.IndexOf("[")));
        }

        public static char Rotate(this char a, int sector)
        {
            //97 - 122 are codes for a to z
            // given case sector 343 translates
            // qzmtzixmtkozyivhz to 
            // veryencryptedname
            // so 113 is advanced to 118
            int charValue = Convert.ToInt32(a);

            charValue += sector%26;
            if (charValue > 122)
            {
                charValue = 97 + (charValue - 123);
            }
            return Convert.ToChar(charValue);
        }
    }
}
