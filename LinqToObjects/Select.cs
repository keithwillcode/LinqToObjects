using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return RunSelectAlgorithm(source, (s, i) => selector(s));
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Int32, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            return RunSelectAlgorithm(source, selector);
        }

        private static IEnumerable<TResult> RunSelectAlgorithm<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, Int32, TResult> selector)
        {
            var i = 0;

            foreach (var element in source)
                yield return selector(element, i++);
        }
    }
}
