﻿using System;
using System.Collections;
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

        public static long ExecutionTimeMs(string what, int reps, Func<IEnumerable, IEnumerable> action)
        {
            Console.WriteLine($"Starting to Benchmark {what}");
            Console.WriteLine("...");
            IEnumerable dataAfterAction =  (data) => action(data);
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
    }
}
