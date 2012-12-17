using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, Int32 count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return RunSkipAlgorithm(source, count);
        }

        private static IEnumerable<TSource> RunSkipAlgorithm<TSource>(this IEnumerable<TSource> source, Int32 count)
        {
            var numberSkipped = 0;

            foreach (var element in source)
            {
                if (numberSkipped == count)
                    yield return element;
                else
                    numberSkipped++;
            }
        }
    }
}