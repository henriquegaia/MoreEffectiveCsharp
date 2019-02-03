using System;
using System.Linq;
using System.Collections.Generic;
using Utilities;
using System.Diagnostics;

namespace MECSharp_35_HowPLINQImplementsParallelAlgorithms
{
    class MECSharp_35_HowPLINQImplementsParallelAlgorithms
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<int> data = SampleData.IntCollection(amount: 10_000, max: 50).ToList();
            Display(data, 0, "data");

            stopwatch.Start();
            var pg178_seq = pg178_Sequential(data);
            stopwatch.Stop();
            Display(pg178_seq, stopwatch.ElapsedMilliseconds, "seq");

            stopwatch.Start();
            var pg178_par = pg178_Parallel(data);
            stopwatch.Stop();
            Display(pg178_par, stopwatch.ElapsedMilliseconds, "plinq");
        }

        private static void Display(IEnumerable<int> data, long timeMs, string what)
        {
            Console.WriteLine($"{what}");
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine($"ms: {timeMs}");
            Console.WriteLine("----");
        }

        static List<int> pg178_Sequential(List<int> data)
        {
            var nums = data
                //.Where(n => n < 5)
                .Select(Predicate())
                .ToList();
            return nums;
        }

        static IEnumerable<int> pg178_Parallel(IEnumerable<int> data)
        {
            var nums = data
                .AsParallel()
                //.Where(n => n < 5)
                .Select(Predicate())
                .ToList();
            return nums;
        }

        private static Func<int, int> Predicate() => (n) => LongRun.FactorialRecursive(n);
    }
}
