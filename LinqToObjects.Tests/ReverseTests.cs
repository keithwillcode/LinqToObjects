using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ReverseTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenSourceIsNull()
        {
            Enumerable.Reverse<Int32>(null);
        }

        [Test]
        public void ReverseInvertsTheOrderOfElementsInASequence()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Reverse();
            var expected = new[] { 3, 2, 1 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
