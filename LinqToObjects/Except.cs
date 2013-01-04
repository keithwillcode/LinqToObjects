using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return Except(first, second, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null)
                throw new ArgumentNullException("first");

            if (second == null)
                throw new ArgumentNullException("second");

            if (comparer == null)
                comparer = EqualityComparer<TSource>.Default;

            return RunExceptAlgorithm(first, second, comparer);
        }

        private static IEnumerable<TSource> RunExceptAlgorithm<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var hash = new HashSet<TSource>(second, comparer);

            foreach (var element in first)
                if (hash.Add(element))
                    yield return element;
        }
    }
}