using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace MECSharp_34_CacheGeneralizedAsyncReturnTypes
{
    class MECSharp_34_CacheGeneralizedAsyncReturnTypes
    {
        static DateTime lastReading;
        const int ReadingFrequencySeconds = 2;
        static List<Task<string>> recentObservations;
        static long totalTimeUsingTaskList = 0;
        static long totalTimeUsingTaskValueList = 0;
        static int iterations = 5;

        static async Task Main(string[] args)
        {
            lastReading = DateTime.Now;
            recentObservations = WeatherData.GenerateData();

            for (int i = 0; i < iterations; i++)
            {
                var elapsed = await pg174_UsingTaskList();
            }
            Console.WriteLine($"totalTimeUsingTaskList: {totalTimeUsingTaskList}");

            //while (true)
            //{
            //    if (DateTime.Now - lastReading > TimeSpan.FromSeconds(ReadingFrequencySeconds))
            //    {
            //        var elapsed = await pg174_UsingTaskList();
            //    }
            //    //Console.WriteLine($"totalTimeUsingTaskList: {totalTimeUsingTaskList}");
            //}
        }

        private static void pg175_UsingTaskValueList()
        {

        }

        private static async Task<long> pg174_UsingTaskList()
        {
            WeatherData.PrintData(recentObservations);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            recentObservations = RetrieveHistoricalData_AsyncMethod();
            stopwatch.Stop();
            lastReading = DateTime.Now;
            long timeElapsed = stopwatch.ElapsedTicks;
            totalTimeUsingTaskList += timeElapsed;
            Console.WriteLine($"-> pg174_UsingTaskList took {timeElapsed} ticks");
            return timeElapsed;
        }

        static List<Task<string>> RetrieveHistoricalData_AsyncMethod()
        {
            if (DateTime.Now - lastReading > TimeSpan.FromSeconds(ReadingFrequencySeconds))
            {
                recentObservations = WeatherData.GenerateData(); ;
            }

            return recentObservations;
        }

        //static ValueTask<IEnumerable<WeatherData>> RetHistData_ValueTask()
        //{
        //    if (DateTime.Now - lastReading > TimeSpan.FromMinutes(5))
        //    {
        //        return new ValueTask<IEnumerable<WeatherData>>(recentObservations);
        //    }

        //    //var obs = await RetObsData();
        //    //recentObservations.Add(obs);
        //    return new ValueTask<IEnumerable<WeatherData>>(recentObservations);
        //}

        // garbage?
        //static async List<Task<WeatherData>> RetrieveObservationData()
        //{
        //    return await Task.Run(() => WeatherData.GenerateData());
        //}

    }

    class WeatherData
    {
        public int Temperature { get; set; }
        public WeatherData() => Temperature = RandomTemperature();

        private int RandomTemperature()
        {
            Random Random = new Random();
            return Random.Next(0, 41);
        }

        public override string ToString() => $"{DateTime.Now} - Temperature: {Temperature.ToString()}";

        public static List<Task<string>> GenerateData()
        {
            Task<string> task1 = AsyncAndThreading.ReadFileAsync(false);
            Task<string> task2 = AsyncAndThreading.ReadFileAsync(false, @"C:\Users\Henrique-private\Desktop\demo2.txt");
            Task<string> task3 = AsyncAndThreading.ReadFileAsync(false, @"C:\Users\Henrique-private\Desktop\demo3.txt");
            List<Task<string>> tasksList = new List<Task<string>>();
            tasksList.Add(task1);
            tasksList.Add(task2);
            tasksList.Add(task3);
            return tasksList;
        }

        public static void PrintData(IEnumerable<Task<string>> data)
        {
            foreach (var task in data)
            {
                Console.WriteLine($"Task id {task.Id} IsCompletedSuccessfully: {task.IsCompletedSuccessfully}");
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
