using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day4;
using Xunit;

namespace AdventOfCodeTests
{
    public class Day4Tests
    {
        [Theory]
        [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", "aaaaabbbzyx")]
        [InlineData("a-b-c-d-e-f-g-h-987[abcde]", "abcdefgh")]
        [InlineData("not-a-real-room-404[oarel]", "notarealroom")]
        [InlineData("totally-real-room-200[decoy]", "totallyrealroom")]
        public void GivenStringReturnName(string s, string expectedName)
        {
            Room room = new Room(s);
            Assert.Equal(expectedName, room.Name);
        }

        [Theory]
        [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", "abxyz")]
        [InlineData("a-b-c-d-e-f-g-h-987[abcde]", "abcde")]
        [InlineData("not-a-real-room-404[oarel]", "oarel")]
        [InlineData("totally-real-room-200[decoy]", "decoy")]

        public void GivenStringReturnCheckSum(string s, string expectedCheckSum)
        {
            Room room = new Room(s);
            Assert.Equal(expectedCheckSum, room.ExtractedCheckSum);
        }

        [Theory]
        [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", 123)]
        [InlineData("a-b-c-d-e-f-g-h-987[abcde]", 987)]
        [InlineData("not-a-real-room-404[oarel]", 404)]
        [InlineData("totally-real-room-200[decoy]", 200)]
        public void GivenStringReturnSector(string s, int expectedSector)
        {
            Room room = new Room(s);
            Assert.Equal(expectedSector, room.Sector);
        }

        [Theory]
        [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", true)]
        [InlineData("ddddd-aaaa-bbb-z-y-x-123[dabxy]", true)]
        [InlineData("a-b-c-d-e-f-g-h-987[abcde]", true)]
        [InlineData("not-a-real-room-404[oarel]", true)]
        [InlineData("totally-real-room-200[decoy]", false)]
        public void GivenStringReturnValid(string s, bool expectedValid)
        {
            Room room = new Room(s);
            Assert.Equal(expectedValid, room.Valid);
        }

        [Theory]
        [InlineData("qzmt-zixmtkozy-ivhz-343[zimth]", "veryencryptedname")]
        public void DecryptRoomName(string input, string expected)
        {
            Room room = new Room(input);

            var result = room.Decrypt();

            Assert.Equal(expected, result);
        }
    }
}
