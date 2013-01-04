using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
                throw new ArgumentNullException("first");

            if (second == null)
                throw new ArgumentNullException("second");

            return RunConcatAlgorithm(first, second);
        }

        private static IEnumerable<TSource> RunConcatAlgorithm<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var element in first)
                yield return element;

            foreach (var element in second)
                yield return element;
        }
    }
}