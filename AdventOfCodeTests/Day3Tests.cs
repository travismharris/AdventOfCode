using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3;
using Xunit;


namespace AdventOfCodeTests
{
    //removed public from class declaration to prevent running tests for old problems
    class Day3Tests
    {
        [Theory]
        [InlineData(5, 10, 25, false)]
        public void ValidSidesForTriangle(int a, int b, int c, bool expected)
        {
            Triangle t = new Triangle(a,b,c);

            var result = t.ValidTriangle;

            Assert.Equal(expected, result);
        }
    }
}
