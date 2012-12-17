using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class RepeatTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionIsThrownWhenCountIsLessThanZero()
        {
            Enumerable.Repeat<Int32>(1, -1);
        }

        [TestMethod]
        public void GeneratesASequenceThatContainsOneRepeatedElement()
        {
            var result = Enumerable.Repeat(1, 5);
            var expected = new[] { 1, 1, 1, 1, 1 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, result));
        }
    }
}
