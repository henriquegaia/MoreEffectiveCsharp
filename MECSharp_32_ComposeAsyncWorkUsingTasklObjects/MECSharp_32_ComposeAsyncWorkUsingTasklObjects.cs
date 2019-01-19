using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Utilities;

namespace MECSharp_32_ComposeAsyncWorkUsingTasklObjects
{
    class MECSharp_32_ComposeAsyncWorkUsingTasklObjects
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatchWorst = new Stopwatch();
            stopWatchWorst.Start();
            LessEfficient();
            stopWatchWorst.Stop();
            Console.WriteLine($"-> worst {stopWatchWorst.ElapsedMilliseconds}");

            Stopwatch stopWatchBest = new Stopwatch();
            stopWatchBest.Start();
            MoreEfficient();
            stopWatchBest.Stop();
            Console.WriteLine($"-> best {stopWatchBest.ElapsedMilliseconds}");
        }

        private static void MoreEfficient()
        {
            var sourceTasks = SourceTasks_pg_163_2();

            foreach (var it in sourceTasks)
            {
                Console.WriteLine(it.Id);
                Console.WriteLine(it.Status);
                Console.WriteLine("---");
            }

            Console.WriteLine("===");
            var outputTasks = sourceTasks.OrderBySourceCompletion();

            foreach (var ot in outputTasks)
            {
                Console.WriteLine(ot.Id);
                Console.WriteLine(ot.Status);
                Console.WriteLine("---");
            }
        }

        private static void LessEfficient()
        {
            var sourceTasks = SourceTasks_pg_163_2();

            foreach (var it in sourceTasks)
            {
                Console.WriteLine(it.Id);
                Console.WriteLine(it.Status);
                Console.WriteLine("---");
            }

            Console.WriteLine("===");
            var outputTasks = sourceTasks.OrderBySourceOrder();

            //foreach (var ot in outputTasks)
            //{
            //    Console.WriteLine(ot.Id);
            //    Console.WriteLine(ot.Status);
            //    Console.WriteLine("---");
            //}
        }

        static IEnumerable<Task<string>> SourceTasks_pg_163_2()
        {
            Task<string> task1 = AsyncAndThreading.ReadFileAsync(false);
            Task<string> task2 = AsyncAndThreading.ReadFileAsync(false, @"C:\Users\Henrique-private\Desktop\demo2.txt");
            Task<string> task3 = AsyncAndThreading.ReadFileAsync(false, @"C:\Users\Henrique-private\Desktop\demo3.txt");
            List<Task<string>> tasksList = new List<Task<string>>();
            tasksList.Add(task1);
            tasksList.Add(task2);
            tasksList.Add(task3);
            var tasksArray = tasksList.ToArray();
            return tasksArray;
        }

    }

}
