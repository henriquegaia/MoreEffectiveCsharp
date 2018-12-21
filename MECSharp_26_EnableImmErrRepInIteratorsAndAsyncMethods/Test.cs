using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MECSharp_26_EnableImmErrRepInIteratorsAndAsyncMethods
{
    public class Test
    {
        public static void Async_problem()
        {
            Task<string> contents = Helper.GetContentsAsync();
            Console.WriteLine("exp not thrown");
            Helper.ShowExceptionsAsync(contents);
        }

        public static void Async_solution()
        {
            Task<string> contents = Helper.GetContentsAsync(true);
            Console.WriteLine("exp not thrown");
            Helper.ShowExceptionsAsync(contents);
        }

        public static void Iterators_problem()
        {
            IEnumerable<int> sample = Helper.GenSampleIterator();
            Console.WriteLine("exp not thrown yet !!!");
            Helper.ShowIteratorSample(sample);
        }

        public static void Iterators_solution()
        {
            IEnumerable<int> sample = Helper.GenSampleIterator(true);
            Console.WriteLine("exp should have been thrown");
            Helper.ShowIteratorSample(sample);
        }
    }
}
