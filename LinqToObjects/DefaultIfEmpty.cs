using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return DefaultIfEmpty(source, default(TSource));
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return RunDefaultIfEmptyAlgorithm(source, defaultValue);
        }

        private static IEnumerable<TSource> RunDefaultIfEmptyAlgorithm<TSource>(IEnumerable<TSource> source, TSource defaultValue)
        {
            var elementFound = false;

            foreach (var element in source)
            {
                elementFound = true;
                yield return element;
            }

            if (elementFound == false)
                yield return defaultValue;
        }
    }
}