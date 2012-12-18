﻿using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class LastTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Last<Int32>(null);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Enumerable.Last<Int32>(null, i => i == 0);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            source.Last();
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenNoElementsMatchThePredicate()
        {
            var source = new[] { 1, 2, 3 };
            source.Last(i => i == 4);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsNullAndPredicateIsProvided()
        {
            var source = new Int32[0];
            source.Last(i => i == 0);
        }

        [Test]
        public void LastReturnsLastElementInSequenceOfLengthOneWhenNoPredicateIsProvided()
        {
            var source = new[] { 3 };
            Assert.AreEqual(3, source.Last());
        }

        [Test]
        public void LastReturnsLastElementInSequenceWhenNoPredicateIsProvided()
        {
            var source = new[] { 1, 2, 3 };
            Assert.AreEqual(3, source.Last());
        }

        [Test]
        public void LastReturnsLastElementInSequenceThatMatchesThePredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.AreEqual(2, source.Last(i => i == 2));
        }
    }
}