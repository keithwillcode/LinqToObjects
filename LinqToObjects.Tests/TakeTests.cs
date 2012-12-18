using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class TakeTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Take<Int32>(null, 1);
        }

        [Test]
        public void EmptySequenceIsReturnedWhenCountIsLessThanOrEqualToZero()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(0);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(Enumerable.Empty<Int32>(), result));
        }

        [Test]
        public void CountElementsAreReturnedWhenCountIsLessThanNumberOfElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(2);
            var expected = new[] { 1, 2 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [Test]
        public void AllElementsAreReturnedWhenCountIsGreaterThanNumberOfElements()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Take(6);
            var expected = new[] { 1, 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
