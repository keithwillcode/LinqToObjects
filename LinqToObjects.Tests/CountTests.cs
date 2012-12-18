using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class CountTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Any<Int32>(null);
        }

        [Test]
        public void CountReturnsZeroWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            Assert.That(source.Count(), Is.EqualTo(0));
        }

        [Test]
        public void CountReturnsOneWhenSourceHasOneElement()
        {
            var source = new[] { 1 };
            Assert.That(source.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CountReturnsTotalNumberOfItemsWhenThereAreMoreThanOneElement()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.Count(), Is.EqualTo(3));
        }

        [Test]
        public void CountReturnsZeroWhenSourceIsEmptyAndPredicateIsUsed()
        {
            var source = new Int32[0];
            Assert.That(source.Count(i => i == 0), Is.EqualTo(0));
        }

        [Test]
        public void CountReturnsZeroWhenPredicateDoesNotMatchAnyElementsInSource()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.Count(i => i == 0), Is.EqualTo(0));
        }

        [Test]
        public void CountReturnsNumberOfElementsThatMatchPredicate()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.Count(i => i >= 2), Is.EqualTo(2));
        }
    }
}
