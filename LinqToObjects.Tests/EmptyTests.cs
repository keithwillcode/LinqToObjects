using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects.Tests
{
    [TestClass]
    public class EmptyTests
    {
        [TestMethod]
        public void ReturnsASequenceThatYieldsNoElements()
        {
            var sequence = Enumerable.Empty<Int32>();
            var enumerator = sequence.GetEnumerator();

            Assert.IsFalse(enumerator.MoveNext());
        }
    }
}
