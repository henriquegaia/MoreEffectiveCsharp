using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MECSharp_27_UseAsyncMethodsForAsyncWork
{
    class Ex1
    {
        private static ConcurrentDictionary<string, Task<string>> cache =
            new ConcurrentDictionary<string, Task<string>>();

        public static void Test()
        {
            FrmCount();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"i = {i}");
                SomeMethodAsync();
            }
        }

        public static async Task SomeMethodAsync()
        {
            FrmCount();

            Console.WriteLine("enter SomeMethodAsync");
            Task awaitable = SomeMethodReturningTask();
            Console.WriteLine("in SomeMethodAsync before await");
            await awaitable;
            Console.WriteLine("in SomeMethodAsync after await");
        }

        private static Task<string> SomeMethodReturningTask()
        {
            FrmCount();

            string key = "1";
            Console.WriteLine("\tenter SomeMethodReturningTask");
            Task<string> output;
            if (!cache.TryGetValue(key, out output))
            {
                output = SomeLongRunningOperation();
                cache.TryAdd("1", output);
            }
            Console.WriteLine("\texit SomeMethodReturningTask");
            return output;
        }

        private static async Task<string> SomeLongRunningOperation()
        {
            FrmCount();

            Console.WriteLine("\t\tI'm starting a long running operation");
            await Task.Delay(2000);
            Console.WriteLine("\t\tI'm finishing a long running operation");
            return "Result";
        }

        private static void FrmCount()
        {
            System.Diagnostics.StackTrace stackTrace =
                            new System.Diagnostics.StackTrace();
            int c = stackTrace.FrameCount;
            Console.WriteLine($"FrameCount: {c}");
        }
    }
}
