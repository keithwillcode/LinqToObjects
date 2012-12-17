using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class SelectTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Select(null, (Int32 i) => i == 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSelectorIsNull()
        {
            var source = new Int32[0];
            Func<Int32, String> selector = null;
            Enumerable.Select(source, selector);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndOverloadIsUsed()
        {
            Enumerable.Select(null, (Int32 i, Int32 index) => i == 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSelectorIsNullAndOverloadIsUsed()
        {
            var source = new Int32[0];
            Func<Int32, Int32, String> selector = null;
            Enumerable.Select(source, selector);
        }

        [TestMethod]
        public void TargetProjectionsOfElementsAreReturnedWhenSourceIsEmpty()
        {
            var source = new Int32[0];
            var expected = new Boolean[0];
            var result = source.Select(i => i == 0);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }

        [TestMethod]
        public void TargetProjectionsOfElementsAreReturnedWhenSourceIsNotEmpty()
        {
            var source = new[] { 1, 2, 3 };
            var expected = new[] { 2, 4, 6 };
            var result = source.Select(i => i * 2);

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}