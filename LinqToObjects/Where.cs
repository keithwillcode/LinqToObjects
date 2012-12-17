using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return RunWhereAlgorithm(source, (s, i) => predicate(s));
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, Int32, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return RunWhereAlgorithm(source, predicate);
        }

        private static IEnumerable<TSource> RunWhereAlgorithm<TSource>(this IEnumerable<TSource> source, Func<TSource, Int32, Boolean> predicate)
        {
            var i = 0;

            foreach (var element in source)
                if (predicate(element, i++))
                    yield return element;
        }
    }
}