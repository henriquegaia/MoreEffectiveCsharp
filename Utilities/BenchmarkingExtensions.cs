using System;
using System.Diagnostics;

namespace Utilities
{
    public static class BenchmarkingExtensions
    {
        public static long ExecutionTimeMs(string what, int reps, Action action)
        {
            Console.WriteLine($"Starting to Benchmark {what}");
            Console.WriteLine("...");
            action();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < reps; i++)
            {
                action();
            }
            stopwatch.Stop();
            long res = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Benchmarking result of{what} (ms): {res}");
            Console.WriteLine();

            return res;
        }

        //public static long ExecutionTimeMs(string what, int reps, Func<List<int>, List<int>> action)
        //{
        //    Console.WriteLine($"Starting to Benchmark {what}");
        //    Console.WriteLine("...");
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    for (int i = 0; i < reps; i++)
        //    {
        //        //action();
        //    }
        //    stopwatch.Stop();
        //    long res = stopwatch.ElapsedMilliseconds;
        //    Console.WriteLine($"Benchmarking result of{what} (ms): {res}");
        //    Console.WriteLine();

        //    return res;
        //}
    }
}
