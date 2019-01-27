using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MECSharp_34_CacheGeneralizedAsyncReturnTypes
{
    class MECSharp_34_CacheGeneralizedAsyncReturnTypes
    {
        static DateTime lastReading;
        const int ReadingFrequencySeconds = 2;
        static List<WeatherData> recentObservations;

        static async Task Main(string[] args)
        {
            lastReading = DateTime.Now;
            recentObservations = WeatherData.GenerateRandomData();

            while (true)
            {
                if (DateTime.Now - lastReading > TimeSpan.FromSeconds(ReadingFrequencySeconds))
                {
                    await pg174_UsingTaskList();
                }
            }
        }

        private static async Task pg174_UsingTaskList()
        {
            WeatherData.PrintData(recentObservations);
            recentObservations = await RetrieveHistoricalData_AsyncMethod();
            lastReading = DateTime.Now;
        }

        static async Task<List<WeatherData>> RetrieveHistoricalData_AsyncMethod()
        {
            if (DateTime.Now - lastReading > TimeSpan.FromSeconds(ReadingFrequencySeconds))
            {
                recentObservations = await RetrieveObservationData(); ;
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

        static async Task<List<WeatherData>> RetrieveObservationData()
        {
            return await Task.Run(() => WeatherData.GenerateRandomData());
        }

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

        public static List<WeatherData> GenerateRandomData()
        {
            var data = new List<WeatherData>();
            for (int i = 0; i < 3; i++)
            {
                data.Add(new WeatherData());
            }
            return data;
        }

        public static void PrintData(List<WeatherData> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
