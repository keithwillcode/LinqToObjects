using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            return Last(source, s => true);
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            var found = false;
            var lastElement = default(TSource);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    found = true;
                    lastElement = element;
                }
            }

            if (found == false)
                throw new InvalidOperationException("The source sequence is empty.");

            return lastElement;
        }
    }
}