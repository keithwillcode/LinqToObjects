using System.Collections.Generic;

namespace LinqToObjects
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Empty<TResult>()
        {
            return EmptyEnumerable<TResult>.GetInstance();
        }

        private static class EmptyEnumerable<T>
        {
            private static IEnumerable<T> emptySequence = new T[0];
            
            public static IEnumerable<T> GetInstance()
            {
                return emptySequence;
            }
        }
    }
}