using System;
using System.Threading.Tasks;

namespace Utilities
{
    public class AsyncWork
    {
        public static async Task Simulate(int secondsDelay = 1) =>
            await Task.Delay(TimeSpan.FromSeconds(secondsDelay));
    }
}
