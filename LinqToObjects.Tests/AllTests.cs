using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class AllTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.All(null, (Int32 i) => i == 0);
        }

        [Test]
        public void AllReturnsTrueWhenSourceIsEmpty()
        {
            var source = new Int32[0];

            Assert.That(source.All(i => i == 0), Is.True);
        }

        [Test]
        public void AllReturnsTrueWhenEveryElementMatchesThePredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.That(source.All(i => i > 0), Is.True);
        }

        [Test]
        public void AllReturnsFalseWhenEveryElementDoesNotMatchThePredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.That(source.All(i => i == 0), Is.False);
        }
    }
}
