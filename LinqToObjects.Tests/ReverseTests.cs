using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ReverseTests
    {
        [Test]
        public void ArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Enumerable.Reverse<Int32>(null));
        }

        [Test]
        public void ReverseInvertsTheOrderOfElementsInASequence()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Reverse();
            var expected = new[] { 3, 2, 1 };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
