using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class FirstTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.First<Int32>(null);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndPredicateIsProvided()
        {
            Enumerable.First<Int32>(null, i => i == 0);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            Enumerable.First<Int32>(source);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenSourceIsEmptyAndPredicateIsProvided()
        {
            var source = new Int32[0];
            Enumerable.First<Int32>(source, i => i == 0);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionIsThrownWhenPredicateDoesNotMatchAnyItem()
        {
            var source = new[] { 1, 2, 3 };
            Enumerable.First<Int32>(source, i => i == 0);
        }

        [Test]
        public void FirstItemFromSourceIsReturnedWhenPredicateIsNotProvided()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.First(), Is.EqualTo(1));
        }

        [Test]
        public void FirstItemThatMatchesThePredicateIsReturned()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.First(i => i == 2), Is.EqualTo(2));
        }
    }
}