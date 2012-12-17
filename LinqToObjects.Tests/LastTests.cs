using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class LastTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Last<Int32>(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Enumerable.Last<Int32>(null, i => i == 0);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            source.Last();
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenNoElementsMatchThePredicate()
        {
            var source = new[] { 1, 2, 3 };
            source.Last(i => i == 4);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsNullAndPredicateIsProvided()
        {
            var source = new Int32[0];
            source.Last(i => i == 0);
        }

        [TestMethod]
        public void LastReturnsLastElementInSequenceOfLengthOneWhenNoPredicateIsProvided()
        {
            var source = new[] { 3 };
            Assert.AreEqual(3, source.Last());
        }

        [TestMethod]
        public void LastReturnsLastElementInSequenceWhenNoPredicateIsProvided()
        {
            var source = new[] { 1, 2, 3 };
            Assert.AreEqual(3, source.Last());
        }

        [TestMethod]
        public void LastReturnsLastElementInSequenceThatMatchesThePredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.AreEqual(2, source.Last(i => i == 2));
        }
    }
}