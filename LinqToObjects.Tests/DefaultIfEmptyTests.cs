using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class DefaultIfEmptyTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.DefaultIfEmpty<Int32>(null));
            }

            [Test]
            public void ReturnsAllElementsOfNonEmptySequence()
            {
                var source = new[] { 1, 2, 3 };
                var result = source.DefaultIfEmpty();
                var expected = new[] { 1, 2, 3 };

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void ReturnsDefaultOfSourceTypeWhenSequenceIsEmpty()
            {
                var source = Enumerable.Empty<Int32>();
                var result = source.DefaultIfEmpty();
                var expected = new[] { 0 };

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class DefaultValueTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.DefaultIfEmpty<Int32>(null, 10));
            }

            [Test]
            public void ReturnsAllElementsOfNonEmptySequence()
            {
                var source = new[] { 1, 2, 3 };
                var result = source.DefaultIfEmpty(10);
                var expected = new[] { 1, 2, 3 };

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void ReturnsDefaultValueWhenSequenceIsEmpty()
            {
                var source = Enumerable.Empty<Int32>();
                var result = source.DefaultIfEmpty(10);
                var expected = new[] { 10 };

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
