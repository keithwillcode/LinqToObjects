using System;
using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<Int32> Range(Int32 start, Int32 count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", "count must be greater than or equal to 0.");

            return RunRangeAlgorithm(start, count);
        }

        private static IEnumerable<Int32> RunRangeAlgorithm(Int32 start, Int32 count)
        {
            for (var i = 0; i < count; i++)
                yield return start + i;
        }
    }
}