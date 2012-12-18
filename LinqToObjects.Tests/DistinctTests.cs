using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class DistinctTests
    {
        [Test]
        public void EmptySequenceIsReturnedWhenSourceContainsNoElements()
        {
            var source = new Int32[0];

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(source, Enumerable.Empty<Int32>()));
        }
        
        [Test]
        public void AllElementsAreReturnedWhenSourceContainsNoDuplicates()
        {
            var source = new[] { 1, 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(source, source.Distinct()));
        }

        [Test]
        public void DuplicatesAreNotReturnedWhenSourceContainsDuplicates()
        {
            var source = new[] { 1, 2, 3, 3 };
            var expected = new[] { 1, 2, 3 };

            Assert.IsTrue(System.Linq.Enumerable.SequenceEqual(expected, source.Distinct()));
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
        {
            Enumerable.Distinct<Int32>(null);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionIsThrownWhenSourceIsNullAndComparerIsProvided()
        {
            Enumerable.Distinct<Int32>(null, EqualityComparer<Int32>.Default);
        }
    }
}