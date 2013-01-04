using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class AggregateTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32>(null, (i, j) => i));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenFuncIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32>(Enumerable.Empty<Int32>(), null));
            }

            [Test]
            public void InvalidOperationExceptionIsThrownWhenSourceContainsNoElements()
            {
                Assert.Throws<InvalidOperationException>(() => Enumerable.Aggregate<Int32>(Enumerable.Empty<Int32>(), (i, j) => i));
            }

            [Test]
            public void FuncIsAppliedToAllElementsInTheSequence()
            {
                var sentence = "the quick brown fox jumps over the lazy dog";
                var words = sentence.Split(' ');
                var reversed = words.Aggregate((workingSentence, next) => next + " " + workingSentence);

                Assert.That(reversed, Is.EqualTo("dog lazy the over jumps fox brown quick the "));
            }
        }

        [TestFixture]
        public class SeedTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32, Double>(null, 0.0d, (i, j) => i));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenFuncIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32, Double>(Enumerable.Empty<Int32>(), 0.0d, null));
            }

            [Test]
            public void FuncIsAppliedToAllElementsInTheSequence()
            {
                var ints = new[] { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
                var numEven = ints.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total);

                Assert.That(numEven, Is.EqualTo(6));
            }
        }

        [TestFixture]
        public class SelectorTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32, Double, String>(null, 0.0d, (i, j) => i, i => Convert.ToString(i)));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenFuncIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32, Double, String>(Enumerable.Empty<Int32>(), 0.0d, null, i => Convert.ToString(i)));
            }

            [Test]
            public void ArgumentNullExceptionIsThrownWhenResultSelectorIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Aggregate<Int32, Double, String>(Enumerable.Empty<Int32>(), 0.0d, (i, j) => i, null));
            }

            [Test]
            public void FuncIsAppliedToAllElementsInTheSequence()
            {
                var fruits = new[] { "apple", "mango", "orange", "passionfruit", "grape" };
                var longestName = fruits.Aggregate("banana", (longest, next) => next.Length > longest.Length ? next : longest, fruit => fruit.ToUpper());

                Assert.That(longestName, Is.EqualTo("PASSIONFRUIT"));
            }
        }
    }
}