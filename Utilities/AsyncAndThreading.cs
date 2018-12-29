using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Utilities
{
    public static class AsyncAndThreading
    {
        public static async Task Simulate(int secondsDelay = 1) =>
            await Task.Delay(TimeSpan.FromSeconds(secondsDelay));

        public static async void FireAndForget(this Task task, Action<Exception> onErrors)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                onErrors(ex);
            }
        }

        public static async void FireAndForget(this Task task, Func<Exception, bool> onErrors)
        {
            try
            {
                await task;
            }
            catch (Exception ex) when (onErrors(ex)) 
            {}
        }

        public static int ThreadCount() => 
            Process.GetCurrentProcess().Threads.Count;
    }

}
