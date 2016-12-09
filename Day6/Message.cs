using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Message
    {
        public List<string>  MessageList { get; set; }

        public Message()
        {
            MessageList = new List<string>();
        }

        public List<string> TurnList(int length)
        {
            string[] turnedList = new string[length];

            foreach (var a in MessageList)
            {
                for (int i = 0; i < length; i++)
                    turnedList[i] += (a[i]);
            }

            return turnedList.ToList();
        }


            
    }
}
