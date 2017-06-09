using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogosoft.Hashing.Tests
{
    [TestFixture, Category("Unit")]
    public class UnitTests
    {
        [TestCase]
        public void CanHexEncodeCorrectly()
        {
            var length = 16;

            var test = new byte[length];

            var expected = "";

            for(var i = 0; i < length; i++)
            {
                expected += "00";
            }

            test.ToHexString().ShouldEqual(expected);
        }

        [TestCase]
        public void CanPartialHexEncodeCorrectly()
        {
            var length = 16;

            var test = new byte[length];

            var expected = "";

            for (var i = 0; i < length / 2; i++)
            {
                expected += "00";
            }

            test.ToHexString(0, length / 2).ShouldEqual(expected);
        }

        [TestCase]
        public void CanPartialHexEncodeCorrectlyWhenGivenLengthGreaterThanByteArrayLength()
        {
            var test = new byte[16];

            test.ToHexString(8, 16).Length.ShouldEqual(16);
        }
    }
}