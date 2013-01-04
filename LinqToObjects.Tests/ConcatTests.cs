using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ConcatTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenFirstIsNull()
        {
            Enumerable.Concat(null, new[] { 2 });
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSecondIsNull()
        {
            Enumerable.Concat(new[] { 2 }, null);
        }

        [Test]
        public void ReturnsAllOriginalElementsInTheInputSequences()
        {
            var first = new[] { 1, 2 };
            var result = first.Concat(new[] { 3, 4 });
            var expected = new[] { 1, 2, 3, 4 };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
