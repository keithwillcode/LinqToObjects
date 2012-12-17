using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static Boolean Any<TSource>(this IEnumerable<TSource> source)
        {
            return Any(source, s => true);
        }

        public static Boolean Any<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var element in source)
                if (predicate(element))
                    return true;

            return false;
        }
    }
}
