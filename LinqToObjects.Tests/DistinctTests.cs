using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class DistinctTests
    {
        [TestMethod]
        public void EmptySequenceIsReturnedWhenSourceContainsNoElements()
        {
            var source = new Int32[0];

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(source, Enumerable.Empty<Int32>()));
        }
        
        [TestMethod]
        public void AllElementsAreReturnedWhenSourceContainsNoDuplicates()
        {
            var source = new[] { 1, 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(source, source.Distinct()));
        }

        [TestMethod]
        public void DuplicatesAreNotReturnedWhenSourceContainsDuplicates()
        {
            var source = new[] { 1, 2, 3, 3 };
            var expected = new[] { 1, 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, source.Distinct()));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Distinct<Int32>(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndComparerIsProvided()
        {
            Enumerable.Distinct<Int32>(null, EqualityComparer<Int32>.Default);
        }
    }
}