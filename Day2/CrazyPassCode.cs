using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;

namespace Day2
{
    public class CrazyPassCode
    {
        public char GetKeyFromCode(string s, char currentKey)
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

        public char GetKeyFromCode(string s)
        {
            return GetKeyFromCode(s, '5');
        }

        public char Up(char key)
        {                           //      1
            switch (key)            //    2 3 4 
            {                       //  5 6 7 8 9
                case '1':           //    A B C
                case '2':           //      D
                case '4':
                case '5':
                case '9':
                    return key;
                case '3':
                    return '1';
                case '6':
                    return '2';
                case '7':
                    return '3';
                case '8':
                    return '4';
                case 'A':
                    return '6';
                case 'B':
                    return '7';
                case 'C':
                    return '8';
                case 'D':
                    return 'B';
                default:
                    return '0';//bad input
            }
        }

        public char Down(char key)   //      1
        {                           //    2 3 4
            switch (key)            //  5 6 7 8 9
            {                       //    A B C
                case '5':           //      D
                case '9':
                case 'A':
                case 'C':
                case 'D':
                    return key;
                case '1':
                    return '3';
                case '2':
                    return '6';
                case '3':
                    return '7';
                case '4':
                    return '8';
                case '6':
                    return 'A';
                case '7':
                    return 'B';
                case '8':
                    return 'C';
                case 'B':
                    return 'D';
                default:
                    return '0';
            }
        }

        public char Right(char key)  //      1
        {                           //    2 3 4
            switch (key)            //  5 6 7 8 9
            {                       //    A B C
                case '1':           //      D
                case '4':
                case '9':
                case 'C':
                case 'D':
                    return key;
                case '5':
                    return '6';
                case '2':
                    return '3';
                case '6':
                    return '7';
                case 'A':
                    return 'B';
                case '3':
                    return '4';
                case '7':
                    return '8';
                case 'B':
                    return 'C';
                case '8':
                    return '9';
                default:
                    return '0';
            }
        }

        public char Left(char key)   //      1
        {                           //    2 3 4
            switch (key)            //  5 6 7 8 9
            {                       //    A B C
                case '1':           //      D
                case '2':
                case '5':
                case 'A':
                case 'D':
                    return key;
                case '9':
                    return '8';
                case '4':
                    return '3';
                case '8':
                    return '7';
                case 'C':
                    return 'B';
                case '3':
                    return '2';
                case '7':
                    return '6';
                case 'B':
                    return 'A';
                case '6':
                    return '5';
                default:
                    return '0';
            }
        }
    }
}