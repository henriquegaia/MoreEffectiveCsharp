using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MECSharp_34_CacheGeneralizedAsyncReturnTypes
{
    class MECSharp_34_CacheGeneralizedAsyncReturnTypes
    {
        static DateTime lastReading = DateTime.Now - TimeSpan.FromMinutes(6);
        static List<WeatherData> recentObservations = new List<WeatherData>();

        static void Main(string[] args)
        {
        }

        static ValueTask<IEnumerable<WeatherData>> RetHistDataAsync()
        {
            if (DateTime.Now - lastReading > TimeSpan.FromMinutes(5))
            {
                return new ValueTask<IEnumerable<WeatherData>>(recentObservations);
            }

            //var obs = await RetObsData();
            //recentObservations.Add(obs);
            return new ValueTask<IEnumerable<WeatherData>>(recentObservations);
        }

        static async Task<WeatherData> RetObsData() => await Task.Run(() => new WeatherData());
    }

    class WeatherData
    {

    }
}
