using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class DoorBreaker
    {
        public string DoorId { get; set; }

        public string EntryCode { get; set; }

        public DoorBreaker(string doorId)
        {
            this.DoorId = doorId;
            EntryCode = "";
            BreakIt();
        }

        public bool FiveZeros(string s)
        {
            if (s.StartsWith("00000"))
                return true;
            return false;
        }

        public bool ValidSixthCharacter(string s)
        {
            int sixthCharValue = Convert.ToInt32(s[5]);

            if (sixthCharValue >= 48 && sixthCharValue <= 55)
                return true;

            return false;
        }

        public void BreakIt()
        {
            List<int> placesToIgnore = new List<int>();
            Int64 i = 1;
            int finds = 0;
            var charArray = new char[8];
            while (finds < 8)
            {
                var md5Result = Crypto.CalculateMD5Hash(DoorId + i.ToString());

                if (FiveZeros(md5Result) && ValidSixthCharacter(md5Result))
                {
                    int place = (int)char.GetNumericValue(md5Result[5]);
                    if (!placesToIgnore.Contains(place))
                    {
                        charArray[place] = md5Result[6];
                        finds++;
                        placesToIgnore.Add(place);
                    }
                }

                i++;

                if (i%25000 == 0)
                {
                    Debug.Write("processing i = " + i + " Entry Code = " + new string(charArray));
                    Debug.WriteLine("");
                }

            }
            EntryCode=new string(charArray);
        }
    }


}
//=  "uqwqemis"