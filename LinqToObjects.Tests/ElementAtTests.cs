using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ElementAtTests
    {
        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.ElementAt<Int32>(null, 0));
        }

        [Test]
        public void ArgumentOutOfRangeExceptionIsThrownWhenIndexIsLessThanZero()
        {
            var source = new[] { 1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => source.ElementAt(-1));
        }

        [Test]
        public void ArgumentOutOfRangeExceptionIsThrownWhenIndexGreaterThanOrEqualToTheNumberOfElementsInSource()
        {
            var source = new[] { 1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => source.ElementAt(2));
        }

        [Test]
        public void ElementAtSpecifiedIndexIsReturned()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.ElementAt(1), Is.EqualTo(2));
        }
    }
}
