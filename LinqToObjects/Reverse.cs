using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return RunReverseAlgorithm(source);
        }

        private static IEnumerable<TSource> RunReverseAlgorithm<TSource>(this IEnumerable<TSource> source)
        {
            var elements = new List<TSource>(source);

            for (var i = elements.Count - 1; i >= 0; i--)
                yield return elements[i];
        }
    }
}