using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class TakeTests
    {
        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Take<Int32>(null, 1));
        }

        [Test]
        public void EmptySequenceIsReturnedWhenCountIsLessThanOrEqualToZero()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(0);

            Assert.That(result, Is.EqualTo(Enumerable.Empty<Int32>()));
        }

        [Test]
        public void CountElementsAreReturnedWhenCountIsLessThanNumberOfElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(2);
            var expected = new[] { 1, 2 };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AllElementsAreReturnedWhenCountIsGreaterThanNumberOfElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(6);
            var expected = new[] { 1, 2, 3 };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
