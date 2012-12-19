using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, Int32 index)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var elementIndex = 0;

            foreach (var element in source)
                if (elementIndex++ == index)
                    return element;

            return default(TSource);
        }
    }
}
