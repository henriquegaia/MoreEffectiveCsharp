using System;
using System.Linq;
using System.Collections.Generic;
using Utilities;

namespace MECSharp_35_HowPLINQImplementsParallelAlgorithms
{
    class MECSharp_35_HowPLINQImplementsParallelAlgorithms
    {
        static void Main(string[] args)
        {
            var data = SampleData.IntCollection(amount: 5, max: 5);
            Display(data);
            Console.WriteLine("----");
            var pg178_seq = pg178_Sequential(data);
            Display(pg178_seq);
        }

        private static void Display(IEnumerable<int> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<int> pg178_Sequential(IEnumerable<int> data)
        {
            var nums = data
                //.Where(n => n < 5)
                .Select(Predicate())
                .ToList();
            return nums;
        }

        private static Func<int, int> Predicate() => (n) => LongRun.FactorialRecursive(n);
    }
}
