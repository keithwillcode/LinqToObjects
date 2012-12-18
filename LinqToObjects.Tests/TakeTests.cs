using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class TakeTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Take<Int32>(null, 1);
        }

        [TestMethod]
        public void EmptySequenceIsReturnedWhenCountIsLessThanOrEqualToZero()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(0);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(Enumerable.Empty<Int32>(), result));
        }

        [TestMethod]
        public void CountElementsAreReturnedWhenCountIsLessThanNumberOfElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(2);
            var expected = new[] { 1, 2 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void AllElementsAreReturnedWhenCountIsGreaterThanNumberOfElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(6);
            var expected = new[] { 1, 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
