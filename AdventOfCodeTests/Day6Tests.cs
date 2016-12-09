using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day6;
using Xunit;

namespace AdventOfCodeTests
{
    public class Day6Tests
    {
        [Fact]
        public void GetCorrectMessageFromGivenInput()
        {
            List<string> input = new List<string>()
            {
                "eedadn", "drvtee", "eandsr", "raavrd",
                "atevrs", "tsrnev", "sdttsa", "rasrtv",
                "nssdts", "ntnada", "svetve", "tesnvt",
                "vntsnd", "vrdear", "dvrsen", "enarar"
            };

            Message message = new Message();

            message.MessageList = input;

            var turn = message.TurnList(6);

            var santaMessage = "";
            foreach (var a in turn)
            {
                santaMessage += a.MostFrequentChar();
            }

            santaMessage = "";
            foreach (var a in turn)
            {
                santaMessage += a.LeastFrequentChar();
            }

            Assert.Equal("easter", santaMessage);
        }
        
    }
}
