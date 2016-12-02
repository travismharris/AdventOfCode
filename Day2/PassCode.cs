using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;

namespace Day2
{
    public class PassCode
    {
        public int GetKeyFromCode(string s, int currentKey)
        {
            foreach (char c in s)
            {
                if (c == 'U')
                {
                    currentKey = Up(currentKey);
                }
                else if (c == 'D')
                {
                    currentKey = Down(currentKey);
                }
                else if (c == 'R')
                {
                    currentKey = Right(currentKey);
                }
                else if (c == 'L')
                {
                    currentKey = Left(currentKey);
                }
            }
            return currentKey;
        }

        public int GetKeyFromCode(string s)
        {
            return GetKeyFromCode(s, 5);
        }

        public int Up(int key)
        {                           //    1 2 3
            switch (key)            //    4 5 6
            {                       //    7 8 9
                case 1:
                case 2:
                case 3:
                    return key;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return key - 3;
                default:
                    return 0;//bad input
            }
        }

        public int Down(int key)
        {                           //    1 2 3
            switch (key)            //    4 5 6
            {                       //    7 8 9
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    return key + 3;
                case 7:
                case 8:
                case 9:
                    return key;
                default:
                    return 0;
            }
        }

        public int Right(int key)
        {                           //    1 2 3
            switch (key)            //    4 5 6
            {                       //    7 8 9
                case 1:
                case 2:
                case 4:
                case 5:
                case 7:
                case 8:
                    return key + 1;
                case 3:
                case 6:
                case 9:
                    return key;
                default:
                    return 0;
            }
        }

        public int Left(int key)
        {                           //    1 2 3
            switch (key)            //    4 5 6
            {                       //    7 8 9
                case 2:
                case 3:
                case 5:
                case 6:
                case 8:
                case 9:
                    return key - 1;
                case 1:
                case 4:
                case 7:
                    return key;
                default:
                    return 0;
            }
        }
    }
}