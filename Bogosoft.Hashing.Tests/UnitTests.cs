using Bogosoft.Testing.Objects;
using NUnit.Framework;
using Should;
using System;
using System.Linq;

namespace Bogosoft.Hashing.Tests
{
    [TestFixture, Category("Unit")]
    public class UnitTests
    {
        [TestCase]
        public void CanGuidEncodeCorrectly()
        {
            var bytes = Integer.RandomSequence(16, 0, 255).ToByteArray();

            var expected = new Guid(bytes);

            bytes.ToGuid().ShouldEqual(expected);

            bytes.ToGuid(0).ShouldEqual(expected);
        }

        [TestCase]
        public void CanPartialGuidEncodeCorrectly()
        {
            byte[] bytes;

            bytes = Integer.RandomSequence(16, 0, 255).ToByteArray();

            var guid = bytes.ToGuid(8);

            guid.ToByteArray().Take(8).SequenceEqual(bytes.Skip(8)).ShouldBeTrue();

            guid.ToByteArray().Skip(8).SequenceEqual(new byte[8]).ShouldBeTrue();
        }

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