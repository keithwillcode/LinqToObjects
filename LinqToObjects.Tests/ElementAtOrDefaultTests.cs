using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ElementAtOrDefaultTests
    {
        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.ElementAt<Int32>(null, 0));
        }

        [Test]
        public void DefaultValueWhenIndexIsLessThanZero()
        {
            var source = new[] { 1 };
            Assert.That(source.ElementAtOrDefault(-1), Is.EqualTo(0));
        }

        [Test]
        public void DefaultValueWhenIndexGreaterThanOrEqualToTheNumberOfElementsInSource()
        {
            var source = new[] { 1 };
            Assert.That(source.ElementAtOrDefault(2), Is.EqualTo(0));
        }

        [Test]
        public void ElementAtSpecifiedIndexIsReturned()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source.ElementAt(1), Is.EqualTo(2));
        }
    }
}
