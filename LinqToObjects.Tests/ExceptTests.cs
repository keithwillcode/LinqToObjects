using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ExceptTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenFirstIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Except<Int32>(null, Enumerable.Empty<Int32>()));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenSecondIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Except<Int32>(Enumerable.Empty<Int32>(), null));
            }

            [Test]
            public void ElementInFirstAndNotSecondIsReturned()
            {
                var first = new[] { 1, 2, 3, 4, 5, 6 };
                var second = new[] { 1, 2, 3, 4, 5 };
                var result = first.Except(second);
                var expected = new[] { 6 };

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void NoElementsAreReturnedWhenFirstIsSubsetOfSecond()
            {
                var first = new[] { 1, 2, 3, 4, 5 };
                var second = new[] { 1, 2, 3, 4, 5, 6 };
                var result = first.Except(second);
                var expected = Enumerable.Empty<Int32>();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
