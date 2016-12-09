using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Ip
    {
        public string Address { get; set; }
        public List<string> UnbracketedParts { get; set; }
        public List<string> BracketedParts { get; set; }
        public bool ConfirmedABBA { get; set; }

        public bool ConfirmedABA { get; set; }
        

        public Ip(string address)
        {
            this.Address = address;
            UnbracketedParts = new List<string>();
            BracketedParts = new List<string>();
            HandleBrackets();
            foreach (var a in UnbracketedParts)
            {
                if (CheckABBA(a))
                {
                    ConfirmedABBA = true;
                    break;
                }
                ConfirmedABBA = false;
            }

            foreach (var a in BracketedParts)
            {
                if (CheckABBA(a))
                    ConfirmedABBA = false;
            }

            ConfirmedABA = false;
            foreach (var a in UnbracketedParts)
            {
                
                var abaResult = CheckABA(a);
                if (abaResult.Count > 0) //found some
                {
                    foreach (var b in abaResult)
                    {
                        foreach (var c in BracketedParts)
                        {
                            if (CheckBAB(c, b))
                            {
                                ConfirmedABA = true;
                                break;
                            }
                        }
                     
                    }
                    if (ConfirmedABA)
                        break;
                }
                
            }
        }

        public void HandleBrackets()
        {
            var workingAddress = Address;
            while(workingAddress.Contains("[") && workingAddress.Contains("]"))
            {
                int lBracket = workingAddress.IndexOf("[");

                int rBracket = workingAddress.IndexOf("]");

                if (rBracket > lBracket) //valid bracket positions
                {
                    UnbracketedParts.Add(workingAddress.Substring(0,lBracket));
                    BracketedParts.Add(workingAddress.Substring(lBracket, rBracket-(lBracket-1)));
                    workingAddress = workingAddress.Remove(0, rBracket+1);
                }
            }
            if (workingAddress.Length > 0)
                UnbracketedParts.Add(workingAddress);
        }

        public bool CheckABBA(string toCheck)
        {
            if (toCheck.Length >= 4)
            {
                for (int i = 0; i < toCheck.Length - 3; i++)
                {
                    if (toCheck[i] == toCheck[i + 3] && toCheck[i + 1] == toCheck[i + 2] && toCheck[i] != toCheck[i + 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<string> CheckABA(string toCheck)
        {
            List<string> returnList = new List<string>();
            if (toCheck.Length >= 3)
            {
                for (int i = 0; i < toCheck.Length - 2; i++)
                {
                    if (toCheck[i] == toCheck[i + 2] && toCheck[i] != toCheck[i + 1])
                    {
                        returnList.Add(new string(toCheck.ToCharArray(), i, 3));
                    }
                }
            }
            return returnList;
        }

        public bool CheckBAB(string toCheck, string toSearch)
        {
            char[] newSearch = new char[3];//turn "ABA" into "BAB"
            newSearch[0] = toSearch[1];
            newSearch[1] = toSearch[0];
            newSearch[2] = toSearch[1];
            toSearch = new string(newSearch);
            if (toCheck.Contains(toSearch))
                return true;
            else
            {
                return false;
            }
        }
    }
}
