using System;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class EmptyTests
    {
        [Test]
        public void ReturnsASequenceThatYieldsNoElements()
        {
            var sequence = Enumerable.Empty<Int32>();
            var enumerator = sequence.GetEnumerator();

            Assert.IsFalse(enumerator.MoveNext());
        }
    }
}
