using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class RepeatTests
    {
        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionIsThrownWhenCountIsLessThanZero()
        {
            Enumerable.Repeat<Int32>(1, -1);
        }

        [Test]
        public void GeneratesASequenceThatContainsOneRepeatedElement()
        {
            var result = Enumerable.Repeat(1, 5);
            var expected = new[] { 1, 1, 1, 1, 1 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
