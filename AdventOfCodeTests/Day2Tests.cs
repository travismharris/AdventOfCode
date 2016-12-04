using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Day2;


namespace AdventOfCodeTests
{
    //removed public from class declaration to prevent running tests for old problems
    class Day2Tests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 1)]
        [InlineData(5, 2)]
        [InlineData(6, 3)]
        [InlineData(7, 4)]
        [InlineData(8, 5)]
        [InlineData(9, 6)]
        public void UpMovesCorrectly(int startkey, int expected)
        {
            PassCode p = new PassCode();
            var result = p.GetKeyFromCode("U", startkey);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 5)]
        [InlineData(3, 6)]
        [InlineData(4, 7)]
        [InlineData(5, 8)]
        [InlineData(6, 9)]
        [InlineData(7, 7)]
        [InlineData(8, 8)]
        [InlineData(9, 9)]
        public void DownMovesCorrectly(int startkey, int expected)
        {
            PassCode p = new PassCode();
            var result = p.GetKeyFromCode("D", startkey);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 6)]
        [InlineData(6, 6)]
        [InlineData(7, 8)]
        [InlineData(8, 9)]
        [InlineData(9, 9)]
        public void RightMovesCorrectly(int startkey, int expected)
        {
            PassCode p = new PassCode();
            var result = p.GetKeyFromCode("R", startkey);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 4)]
        [InlineData(5, 4)]
        [InlineData(6, 5)]
        [InlineData(7, 7)]
        [InlineData(8, 7)]
        [InlineData(9, 8)]
        public void LeftMovesCorrectly(int startkey, int expected)
        {
            PassCode p = new PassCode();
            var result = p.GetKeyFromCode("L", startkey);

            Assert.Equal(expected, result);
        }



        [Fact]
        public void MyCodeYieldsProvidedSolution()
        {
            List<string> inputs = new List<string>() { "ULL", "RRDDD", "LURDL", "UUUUD"};

            PassCode pee = new PassCode();
            List<int> entryCode = new List<int>();
            var currentKey = 5;
            foreach (var s in inputs)
            {
                currentKey = (pee.GetKeyFromCode(s, currentKey));
                entryCode.Add(currentKey);
            }
            Assert.Equal(entryCode[0], 1); //1985
            Assert.Equal(entryCode[1], 9);
            Assert.Equal(entryCode[2], 8);
            Assert.Equal(entryCode[3], 5);
        }

        [Fact]
        public void CrazyCodeYieldsProvidedSolution()
        {
            List<string> inputs = new List<string>() { "ULL", "RRDDD", "LURDL", "UUUUD" };

            CrazyPassCode pee = new CrazyPassCode();
            List<char> entryCode = new List<char>();
            var currentKey = '5';
            foreach (var s in inputs)
            {
                currentKey = (pee.GetKeyFromCode(s, currentKey));
                entryCode.Add(currentKey);
            }
            Assert.Equal(entryCode[0], '5'); //1985
            Assert.Equal(entryCode[1], 'D');
            Assert.Equal(entryCode[2], 'B');
            Assert.Equal(entryCode[3], '3');
        }
    }
}
