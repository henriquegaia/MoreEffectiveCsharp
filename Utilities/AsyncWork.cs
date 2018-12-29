using System.Threading.Tasks;

namespace Utilities
{
    public class AsyncWork
    {
        public static async Task Simulate(int secondsDelay = 1) =>
            await Task.Delay(secondsDelay);

        public static async Task Simulate_2() =>
            await Task.Delay(2_000);

        public static async Task Simulate_3() =>
            await Task.Delay(3_000);

    }
}
