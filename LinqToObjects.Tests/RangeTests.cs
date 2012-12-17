using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionIsThrownWhenCountIsLessThanZero()
        {
            Enumerable.Range(0, -1);
        }

        [TestMethod]
        public void RangeReturnsStartWhenCountIsOne()
        {
            var range = Enumerable.Range(0, 1);
            var expected = new[] { 0 };
            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, range));
        }

        [TestMethod]
        public void RangeReturnsIntegralNumbersWithinAGivenRange()
        {
            var range = Enumerable.Range(0, 5);
            var expected = new[] { 0, 1, 2, 3, 4 };
            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, range));
        }
    }
}
