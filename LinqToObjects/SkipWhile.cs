using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return RunSkipWhileAlgorithm(source, (s, i) => predicate(s));
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, Int32, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return RunSkipWhileAlgorithm(source, predicate);
        }

        private static IEnumerable<TSource> RunSkipWhileAlgorithm<TSource>(this IEnumerable<TSource> source, Func<TSource, Int32, Boolean> predicate)
        {
            var skip = true;
            var index = 0;

            foreach (var element in source)
            {
                skip = skip && predicate(element, index++);

                if (skip == false)
                    yield return element;
            }
        }
    }
}