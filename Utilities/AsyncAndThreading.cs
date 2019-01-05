using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public static class AsyncAndThreading
    {
        public static Task<double> ComputeValueAsync() =>
            Task.Run(() => LongRun.ComputeValue());

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
            { }
        }

        public static int ThreadCount() =>
            Process.GetCurrentProcess().Threads.Count;

        public static async Task<string> ReadFileAsync(
            bool continueOnCapturedContext, string filename = @"C:\Users\Henrique-private\Desktop\test2.txt")
        {
            byte[] result;

            using (FileStream SourceStream = File.Open(filename, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream
                    .ReadAsync(result, 0, (int)SourceStream.Length)
                    .ConfigureAwait(continueOnCapturedContext);
            }

            return Encoding.ASCII.GetString(result);
        }

        public static ExecutionContext GetExecutionContext()
        {
            ExecutionContext executionContext = Thread.CurrentThread.ExecutionContext;
            return executionContext;
        }

        public static int GetThreadId() =>
            Thread.CurrentThread.ManagedThreadId;
    }

}
