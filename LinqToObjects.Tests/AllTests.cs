using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class AllTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.All(null, (Int32 i) => i == 0);
        }

        [TestMethod]
        public void AllReturnsTrueWhenSourceIsEmpty()
        {
            var source = new Int32[0];

            Assert.IsTrue(source.All(i => i == 0));
        }

        [TestMethod]
        public void AllReturnsTrueWhenEveryElementMatchesThePredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.IsTrue(source.All(i => i < 4));
        }

        [TestMethod]
        public void AllReturnsFalseWhenEveryElementDoesNotMatchThePredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.IsFalse(source.All(i => i < 3));
        }
    }
}
