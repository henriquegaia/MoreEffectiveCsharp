using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MECSharp_26_EnableImmErrRepInIteratorsAndAsyncMethods
{
    class Helper
    {
        public static IEnumerable<int> GenSampleIterator(bool sol = false)
        {
            List<int> lst = new List<int> { 1, 2, 5 };
            var sample = sol
                ? IteratorExp<int>.GenSample_solution(lst, -2)
                : IteratorExp<int>.GenSample_problem(lst, -2);
            return sample;
        }

        public static void ShowIteratorSample(IEnumerable<int> sample)
        {
            foreach (var item in sample)
            {
                Console.WriteLine(item);
            }
        }

        public static void ShowExceptionsAsync(Task<string> contents)
        {
            foreach (var excp in contents.Exception.InnerExceptions)
            {
                Console.WriteLine(excp.Message);
            }
        }

        public static Task<string> GetContentsAsync(bool sol = false)
        {
            string url = null;
            AsyncExp<string> exp = new AsyncExp<string>();
            Task<string> contents = sol
                ? exp.LoadMessage_solution(url)
                : exp.LoadMessage_problem(url);
            return contents;
        }

    }
}
