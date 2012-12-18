using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, Int32 count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (count <= 0)
                return Enumerable.Empty<TSource>();

            return RunTakeAlgorithm(source, count);
        }

        private static IEnumerable<TSource> RunTakeAlgorithm<TSource>(this IEnumerable<TSource> source, Int32 count)
        {
            var numberTaken = 0;

            foreach (var element in source)
            {
                yield return element;

                if (++numberTaken == count)
                    yield break;
            }
        }
    }
}