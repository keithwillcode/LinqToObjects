using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class LastTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test, ExpectedException(typeof(ArgumentNullException))]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Enumerable.Last<Int32>(null);
            }

            [Test, ExpectedException(typeof(InvalidOperationException))]
            public void InvalidOperationExceptionIsThrownWhenSourceIsEmpty()
            {
                var source = new Int32[0];
                source.Last();
            }

            [Test]
            public void LastReturnsLastElementInSequenceOfLengthOneWhenNoPredicateIsProvided()
            {
                var source = new[] { 3 };
                Assert.That(source.Last(), Is.EqualTo(3));
            }

            [Test]
            public void LastReturnsLastElementInSequenceWhenNoPredicateIsProvided()
            {
                var source = new[] { 1, 2, 3 };
                Assert.That(source.Last(), Is.EqualTo(3));
            }
        }

        [TestFixture]
        public class PredicateTests
        {
            [Test, ExpectedException(typeof(ArgumentNullException))]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Enumerable.Last<Int32>(null, i => i == 0);
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
            public void LastReturnsLastElementInSequenceThatMatchesThePredicate()
            {
                var source = new[] { 1, 2, 3 };
                Assert.That(source.Last(i => i == 2), Is.EqualTo(2));
            }
        }
    }
}