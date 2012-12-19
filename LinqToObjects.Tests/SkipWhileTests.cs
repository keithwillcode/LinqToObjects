using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class SkipWhileTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.SkipWhile<Int32>(null, i => i < 0));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenPredicateIsNull()
            {
                Func<Int32, Boolean> predicate = null;
                Assert.Throws<ArgumentNullException>(() => Enumerable.SkipWhile<Int32>(Enumerable.Empty<Int32>(), predicate));
            }

            [Test]
            public void EmptySequenceIsReturnedWhenPredicateMatchesAllElements()
            {
                var source = new[] { 1, 2, 3 };
                var result = source.SkipWhile(i => i >= 1);

                Assert.That(result, Is.EqualTo(Enumerable.Empty<Int32>()));
            }

            [Test]
            public void ElementsRemainingInSequenceAfterPredicateDoesNotMatchAreReturned()
            {
                var source = new[] { 1, 2, 3 };
                var result = source.SkipWhile(i => i == 1 || i == 3);
                var expected = new[] { 2, 3 };

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class IndexedPredicateTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.SkipWhile<Int32>(null, (i, j) => i < 0));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenPredicateIsNull()
            {
                Func<Int32, Int32, Boolean> predicate = null;
                Assert.Throws<ArgumentNullException>(() => Enumerable.SkipWhile<Int32>(Enumerable.Empty<Int32>(), predicate));
            }

            [Test]
            public void EmptySequenceIsReturnedWhenPredicateMatchesAllElements()
            {
                var source = new[] { 1, 2, 3 };
                var result = source.SkipWhile((i, j) => i >= 1 && j >= 0);

                Assert.That(result, Is.EqualTo(Enumerable.Empty<Int32>()));
            }

            [Test]
            public void ElementsRemainingInSequenceAfterPredicateDoesNotMatchAreReturned()
            {
                var source = new[] { 1, 2, 3 };
                var result = source.SkipWhile((i, j) => (i == 1 || i == 3) && j > -1);
                var expected = new[] { 2, 3 };

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}