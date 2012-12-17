using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static Int32 Count<TSource>(this IEnumerable<TSource> source)
        {
            return Count(source, s => true);
        }

        public static Int32 Count<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            var count = 0;

            foreach (var element in source)
                if (predicate(element))
                    count++;

            return count;
        }
    }
}