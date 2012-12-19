using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static Boolean Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            return Contains(source, value, EqualityComparer<TSource>.Default);
        }

        public static Boolean Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (comparer == null)
                comparer = EqualityComparer<TSource>.Default;

            return RunContainsAlgorithm(source, value, comparer);
        }

        private static Boolean RunContainsAlgorithm<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            foreach (var element in source)
                if (comparer.Equals(element, value))
                    return true;

            return false;
        }
    }
}
