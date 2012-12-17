using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class CountTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Any<Int32>(null);
        }

        [TestMethod]
        public void CountReturnsZeroWhenSourceIsEmpty()
        {
            var source = new Int32[0];

            Assert.AreEqual(0, source.Count());
        }

        [TestMethod]
        public void CountReturnsOneWhenSourceHasOneElement()
        {
            var source = new[] { 1 };

            Assert.AreEqual(1, source.Count());
        }

        [TestMethod]
        public void CountReturnsTotalNumberOfItemsWhenThereAreMoreThanOneElement()
        {
            var source = new[] { 1, 2, 3 };

            Assert.AreEqual(3, source.Count());
        }

        [TestMethod]
        public void CountReturnsZeroWhenSourceIsEmptyAndPredicateIsUsed()
        {
            var source = new Int32[0];

            Assert.AreEqual(0, source.Count(i => i == 0));
        }

        [TestMethod]
        public void CountReturnsZeroWhenPredicateDoesNotMatchAnyElementsInSource()
        {
            var source = new[] { 1, 2, 3 };

            Assert.AreEqual(0, source.Count(i => i == 0));
        }

        [TestMethod]
        public void CountReturnsNumberOfElementsThatMatchPredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.AreEqual(2, source.Count(i => i >= 2));
        }
    }
}
