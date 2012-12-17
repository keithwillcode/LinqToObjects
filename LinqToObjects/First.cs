using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            return First(source, s => true);
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var element in source)
                if (predicate(element))
                    return element;

            throw new InvalidOperationException("The source sequence is empty.");
        }
    }
}
