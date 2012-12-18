using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class SelectTests
    {
        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Select(null, (Int32 i) => i == 0));
        }

        [Test]
        public void ArgumentNullExceptionIsThrownWhenSelectorIsNull()
        {
            var source = new Int32[0];
            Func<Int32, String> selector = null;
            Assert.Throws<ArgumentNullException>(() => Enumerable.Select(source, selector));
        }

        [Test]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Select(null, (Int32 i, Int32 index) => i == 0));
        }

        [Test]
        public void ArgumentNullExceptionIsThrownWhenSelectorIsNullAndOverloadIsUsed()
        {
            var source = new Int32[0];
            Func<Int32, Int32, String> selector = null;
            Assert.Throws<ArgumentNullException>(() => Enumerable.Select(source, selector));
        }

        [Test]
        public void TargetProjectionsOfElementsAreReturnedWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            var expected = new Boolean[0];
            var result = source.Select(i => i == 0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TargetProjectionsOfElementsAreReturnedWhenSourceIsNotEmpty()
        {
            var source = new[] { 1, 2, 3 };
            var expected = new[] { 2, 4, 6 };
            var result = source.Select(i => i * 2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}