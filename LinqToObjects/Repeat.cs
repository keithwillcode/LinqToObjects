using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, Int32 count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", "count must be greater than or equal to 0.");

            return RunRepeatAlgorithm(element, count);
        }

        private static IEnumerable<TResult> RunRepeatAlgorithm<TResult>(TResult element, Int32 count)
        {
            for (var i = 0; i < count; i++)
                yield return element;
        }
    }
}