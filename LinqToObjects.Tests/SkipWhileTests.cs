﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class SkipWhileTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.SkipWhile<Int32>(null, i => i < 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Enumerable.SkipWhile<Int32>(null, (i, j) => i < 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenPredicateIsNull()
        {
            Func<Int32, Boolean> predicate = null;
            Enumerable.SkipWhile<Int32>(Enumerable.Empty<Int32>(), predicate);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenPredicateIsNullAndOverloadIsUsed()
        {
            Func<Int32, Int32, Boolean> predicate = null;
            Enumerable.SkipWhile<Int32>(Enumerable.Empty<Int32>(), predicate);
        }

        [TestMethod]
        public void EmptySequenceIsReturnedWhenPredicateMatchesAllElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.SkipWhile(i => i >= 1);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(Enumerable.Empty<Int32>(), result));
        }

        [TestMethod]
        public void EmptySequenceIsReturnedWhenPredicateMatchesAllElementsAndOverloadIsUsed()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.SkipWhile((i, j) => i >= 1 && j >= 0);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(Enumerable.Empty<Int32>(), result));
        }

        [TestMethod]
        public void ElementsRemainingInSequenceAfterPredicateDoesNotMatchAreReturned()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.SkipWhile(i => i == 1 || i == 3);
            var expected = new[] { 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void ElementsRemainingInSequenceAfterPredicateDoesNotMatchAreReturnedWhenOverloadIsUsed()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.SkipWhile((i, j) => (i == 1 || i == 3) && j > -1);
            var expected = new[] { 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}