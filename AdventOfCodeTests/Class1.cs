using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests
{
    public class Class1
    {
        [Theory]
        [InlineData("L2", -2, 0, 270)]
        [InlineData("R2", 2, 0, 90)]
        public void MoveWorksCorrectly(string move, int x, int y, int facing)
        {
            Me travis = new Me();
            Move nextMove = new Move(move);
            travis.Move(nextMove);
            Assert.Equal(travis.Facing , facing);
            Assert.Equal(travis.X, x);
            Assert.Equal(travis.Y, y);
        }

        [Theory]
        [InlineData("L2", "L2", -2, -2, 180)]
        [InlineData("R2", "R2", 2, -2, 180)]
        [InlineData("R5", "L2", 5, 2, 0)]
        [InlineData("L7", "R2", -7, 2, 0)]
        public void TwoMovesWorksCorrectly(string move, string move2, int x, int y, int facing)
        {
            Me travis = new Me();
            Move thisMove = new Move(move);
            Move nextMove = new Move(move2);
            travis.Move(thisMove);
            travis.Move(nextMove);
            Assert.Equal(travis.Facing, facing);
            Assert.Equal(travis.X, x);
            Assert.Equal(travis.Y, y);
        }

        [Theory]
        [InlineData("L1", "L1", "L1", "L1", 0, 0)]
        public void GoInCircleConfirmSamePlaceTwice(string move1, string move2, string move3, string move4, int x, int y)
        {
            Me travis = new Me();
            Move first = new Move(move1);
            Move second = new Move(move2);
            Move third = new Move(move3);
            Move fourth = new Move(move4);

            travis.Move(first);
            travis.Move(second);
            travis.Move(third);
            travis.Move(fourth);
            Assert.Equal(travis.X, x);
            Assert.Equal(travis.Y, y);
        }
        
    }
}
