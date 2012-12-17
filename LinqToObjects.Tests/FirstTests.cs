using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class FirstTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.First<Int32>(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndPredicateIsProvided()
        {
            Enumerable.First<Int32>(null, i => i == 0);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            Enumerable.First<Int32>(source);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsEmptyAndPredicateIsProvided()
        {
            var source = new Int32[0];
            Enumerable.First<Int32>(source, i => i == 0);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenPredicateDoesNotMatchAnyItem()
        {
            var source = new[] { 1, 2, 3 };
            Enumerable.First<Int32>(source, i => i == 0);
        }

        [TestMethod]
        public void FirstItemFromSourceIsReturnedWhenPredicateIsNotProvided()
        {
            var source = new[] { 1, 2, 3 };
            Assert.AreEqual(1, source.First());
        }

        [TestMethod]
        public void FirstItemThatMatchesThePredicateIsReturned()
        {
            var source = new[] { 1, 2, 3 };
            Assert.AreEqual(2, source.First(i => i == 2));
        }
    }
}