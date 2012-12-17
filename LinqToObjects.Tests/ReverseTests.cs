using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionWhenSourceIsNull()
        {
            Enumerable.Reverse<Int32>(null);
        }

        [TestMethod]
        public void ReverseInvertsTheOrderOfElementsInASequence()
        {
            var source = new[] { 1, 2, 3 };
            var result = source.Reverse();
            var expected = new[] { 3, 2, 1 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
