using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (func == null)
                throw new ArgumentNullException("func");

            var found = false;
            var aggregateValue = default(TSource);

            foreach (var element in source)
            {
                found = true;
                aggregateValue = func(aggregateValue, element);
            }

            if (!found)
                throw new InvalidOperationException("source contains no elements.");

            return aggregateValue;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            return Aggregate(source, seed, func, t => t);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (func == null)
                throw new ArgumentNullException("func");

            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");

            var aggregateValue = seed;

            foreach (var element in source)
                aggregateValue = func(aggregateValue, element);

            return resultSelector(aggregateValue);
        }
    }
}
