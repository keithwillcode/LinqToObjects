using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class RangeTests
    {
        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionIsThrownWhenCountIsLessThanZero()
        {
            Enumerable.Range(0, -1);
        }

        [Test]
        public void RangeReturnsStartWhenCountIsOne()
        {
            var range = Enumerable.Range(0, 1);
            var expected = new[] { 0 };
            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, range));
        }

        [Test]
        public void RangeReturnsIntegralNumbersWithinAGivenRange()
        {
            var range = Enumerable.Range(0, 5);
            var expected = new[] { 0, 1, 2, 3, 4 };
            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, range));
        }
    }
}
