using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            return Distinct(source, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (comparer == null)
                comparer = EqualityComparer<TSource>.Default;

            return RunDistinctAlgorithm(source, comparer);
        }

        private static IEnumerable<TSource> RunDistinctAlgorithm<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            var elementsSeen = new HashSet<TSource>(comparer);

            foreach (var element in source)
            {
                if (elementsSeen.Contains(element) == false)
                {
                    elementsSeen.Add(element);
                    yield return element;
                }
            }
        }
    }
}
