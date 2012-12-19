using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class ContainsTests
    {
        [TestFixture]
        public class DefaultTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Contains<Int32>(null, 0));
            }

            [Test]
            public void ReturnsTrueWhenElementIsInSource()
            {
                var source = new[] { 1, 2, 3 };
                Assert.That(source.Contains(2), Is.True);
            }

            [Test]
            public void ReturnsFalseWhenElementIsNotInSource()
            {
                var source = new[] { 1, 2, 3 };
                Assert.That(source.Contains(4), Is.False);
            }
        }

        [TestFixture]
        public class EqualityComparerTests
        {
            [Test]
            public void ArgumentNullExceptionIsThrownWhenSourceIsNull()
            {
                Assert.Throws<ArgumentNullException>(() => Enumerable.Contains<Int32>(null, 0, EqualityComparer<Int32>.Default));
            }

            [Test]
            public void ReturnsTrueWhenElementIsInSource()
            {
                var source = new[] { 1, 2, 3 };
                Assert.That(source.Contains(2, EqualityComparer<Int32>.Default), Is.True);
            }

            [Test]
            public void ReturnsFalseWhenElementIsNotInSource()
            {
                var source = new[] { 1, 2, 3 };
                Assert.That(source.Contains(4, EqualityComparer<Int32>.Default), Is.False);
            }
        }
    }
}
