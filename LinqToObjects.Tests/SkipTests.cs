using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class SkipTests
    {
        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Skip<Int32>(null, 0));
        }

        [Test]
        public void EmptySequenceIsReturnedWhenSourceContainsFewerThanCountElements()
        {
            var source = new[] { 1 };
            var result = source.Skip(2);

            Assert.That(result, Is.EqualTo(Enumerable.Empty<Int32>()));
        }

        [Test]
        public void AllElementsOfSourceAreYieldedWhenCountIsLessThanOrEqualToZero()
        {
            var source = new[] { 1 };
            var result = source.Skip(0);
            var expected = new[] { 1 };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ElementsBeforeCountAreSkipped()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var result = source.Skip(3);
            var expected = new[] { 4, 5 };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}