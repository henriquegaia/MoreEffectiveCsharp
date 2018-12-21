using System;
using System.Collections.Generic;

namespace MECSharp_26_EnableImmErrRepInIteratorsAndAsyncMethods
{
    class IteratorExp<T>
    {
        public static IEnumerable<T> GenSample_problem(IEnumerable<T> seq, int sampleFreq)
        {
            CheckArgs(seq, sampleFreq);

            int i = 0;

            foreach (T item in seq)
            {
                i++;
                if (sampleFreq % i == 0)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> GenSample_solution(IEnumerable<T> seq, int sampleFreq)
        {
            CheckArgs(seq, sampleFreq);

            return genSample_solution_implem();

            IEnumerable<T> genSample_solution_implem()
            {
                int i = 0;

                foreach (T item in seq)
                {
                    i++;
                    if (sampleFreq % i == 0)
                    {
                        yield return item;
                    }
                }
            }
        }

        private static void CheckArgs(IEnumerable<T> seq, int sampleFreq)
        {
            if (seq == null)
            {
                throw new ArgumentException("can't be null", paramName: nameof(seq));
            }

            if (sampleFreq < 1)
            {
                throw new ArgumentException("has to be positive", paramName: nameof(sampleFreq));
            }
        }
    }
}
