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
            Assert.That(source, Is.EqualTo(Enumerable.Empty<Int32>()));
        }
        
        [Test]
        public void AllElementsAreReturnedWhenSourceContainsNoDuplicates()
        {
            var source = new[] { 1, 2, 3 };
            Assert.That(source, Is.EqualTo(source.Distinct()));
        }

        [Test]
        public void DuplicatesAreNotReturnedWhenSourceContainsDuplicates()
        {
            var source = new[] { 1, 2, 3, 3 };
            var expected = new[] { 1, 2, 3 };

            Assert.That(source.Distinct(), Is.EqualTo(expected));
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