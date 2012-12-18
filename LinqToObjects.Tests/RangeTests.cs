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

            Assert.That(range, Is.EqualTo(expected));
        }

        [Test]
        public void RangeReturnsIntegralNumbersWithinAGivenRange()
        {
            var range = Enumerable.Range(0, 5);
            var expected = new[] { 0, 1, 2, 3, 4 };

            Assert.That(range, Is.EqualTo(expected));
        }
    }
}
