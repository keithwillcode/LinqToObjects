using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class WhereTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Where(null, (Int32 i) => i == 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Enumerable.Where(null, (Int32 i, Int32 index) => i == 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenPredicateIsNull()
        {
            Func<Int32, Boolean> predicate = null;
            Enumerable.Where(new Int32[0], predicate);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenPredicateIsNullAndOverloadIsUsed()
        {
            Func<Int32, Int32, Boolean> predicate = null;
            Enumerable.Where(new Int32[0], predicate);
        }

        [TestMethod]
        public void ResultIsEmptyWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            var expected = new Int32[0];
            var result = source.Where(i => i == 0);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ResultIsEmptyWhenSourceIsEmptyAndTheOverloadIsUsed()
        {
            var source = new Int32[0];
            var expected = new Int32[0];
            var result = source.Where((Int32 i, Int32 index) => i == 0);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ResultContainsItemsMatchedByThePredicate()
        {
            var source = new[] { 1, 2, 3, 1, 4, 5 };
            var expected = new[] { 1, 2, 1 };
            var result = source.Where(i => i == 1 || i == 2);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ResultContainsItemsMatchedByThePredicateAndTheOverloadIsUsed()
        {
            var source = new[] { 1, 2, 3, 1, 4, 5 };
            var expected = new[] { 1, 2, 1 };
            var result = source.Where((Int32 i, Int32 index) => i == 1 || i == 2);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
