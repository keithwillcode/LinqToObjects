using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class AnyTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Any<Int32>(null);
        }

        [Test]
        public void AnyReturnsFalseWhenSequencyIsEmpty()
        {
            var source = new Int32[0];
            Assert.That(source.Any(), Is.False);
        }

        [Test]
        public void AnyReturnsTrueWhenAtLeastOneElementExists()
        {
            var source = new[] { 1 };
            Assert.That(source.Any(), Is.True);
        }

        [Test]
        public void AnyReturnsFalseWhenNoElementsMatchThePredicate()
        {
            var source = new[] { 1 };
            Assert.That(source.Any(i => i == 0), Is.False);
        }

        [Test]
        public void AnyReturnsTrueWhenAtLeastOneElementMatchesThePredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.That(source.Any(i => i == 1), Is.True);
        }

        [Test]
        public void AnyReturnsTrueWhenNumberOfElementsIsGreaterThanMaxInt()
        {
            var source = CreateIEnumerableLongerThanMaxInt();

            Assert.That(source.Any(i => i == 1), Is.True);
        }

        private IEnumerable<Int32> CreateIEnumerableLongerThanMaxInt()
        {
            for (var i = 0; i < Int32.MaxValue; i++)
                yield return i;

            yield return 1;
        }
    }
}
