using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static Boolean All<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var element in source)
                if (predicate(element) == false)
                    return false;

            return true;
        }
    }
}