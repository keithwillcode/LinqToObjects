using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Any<Int32>(null);
        }

        [TestMethod]
        public void AnyReturnsFalseWhenSequencyIsEmpty()
        {
            var source = new Int32[0];

            Assert.IsFalse(source.Any());
        }

        [TestMethod]
        public void AnyReturnsTrueWhenAtLeastOneElementExists()
        {
            var source = new[] { 1 };

            Assert.IsTrue(source.Any());
        }

        [TestMethod]
        public void AnyReturnsFalseWhenNoElementsMatchThePredicate()
        {
            var source = new[] { 1 };

            Assert.IsFalse(source.Any(i => i == 0));
        }

        [TestMethod]
        public void AnyReturnsTrueWhenAtLeastOneElementMatchesThePredicate()
        {
            var source = new[] { 1, 2, 3 };

            Assert.IsTrue(source.Any(i => i == 1));
        }

        [TestMethod]
        public void AnyReturnsTrueWhenNumberOfElementsIsGreaterThanMaxInt()
        {
            var source = CreateIEnumerableLongerThanMaxInt();

            Assert.IsTrue(source.Any(i => i == 1));
        }

        private IEnumerable<Int32> CreateIEnumerableLongerThanMaxInt()
        {
            for (var i = 0; i < Int32.MaxValue; i++)
                yield return i;

            yield return 1;
        }
    }
}
