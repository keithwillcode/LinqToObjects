using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class WhereTests
    {
        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Where(null, (Int32 i) => i == 1));
        }

        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Where(null, (Int32 i, Int32 index) => i == 1));
        }

        [Test]
        public void ArgumentNullExceptionIsThrownWhenPredicateIsNull()
        {
            Func<Int32, Boolean> predicate = null;
            Assert.Throws<ArgumentNullException>(() => Enumerable.Where(new Int32[0], predicate));
        }

        [Test]
        public void ArgumentNullExceptionIsThrownWhenPredicateIsNullAndOverloadIsUsed()
        {
            Func<Int32, Int32, Boolean> predicate = null;
            Assert.Throws<ArgumentNullException>(() => Enumerable.Where(new Int32[0], predicate));
        }

        [Test]
        public void ResultIsEmptyWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            var expected = new Int32[0];
            var result = source.Where(i => i == 0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ResultIsEmptyWhenSourceIsEmptyAndTheOverloadIsUsed()
        {
            var source = new Int32[0];
            var expected = new Int32[0];
            var result = source.Where((Int32 i, Int32 index) => i == 0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ResultContainsItemsMatchedByThePredicate()
        {
            var source = new[] { 1, 2, 3, 1, 4, 5 };
            var expected = new[] { 1, 2, 1 };
            var result = source.Where(i => i == 1 || i == 2);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ResultContainsItemsMatchedByThePredicateAndTheOverloadIsUsed()
        {
            var source = new[] { 1, 2, 3, 1, 4, 5 };
            var expected = new[] { 1, 2, 1 };
            var result = source.Where((Int32 i, Int32 index) => i == 1 || i == 2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
