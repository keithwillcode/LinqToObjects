using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class SkipTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Skip<Int32>(null, 0);
        }

        [TestMethod]
        public void EmptySequenceIsReturnedWhenSourceContainsFewerThanCountElements()
        {
            var source = new[] { 1 };
            var result = source.Skip(2);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(Enumerable.Empty<Int32>(), result));
        }

        [TestMethod]
        public void AllElementsOfSourceAreYieldedWhenCountIsLessThanOrEqualToZero()
        {
            var source = new[] { 1 };
            var result = source.Skip(0);
            var expected = new[] { 1 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ElementsBeforeCountAreSkipped()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var result = source.Skip(3);
            var expected = new[] { 4, 5 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}