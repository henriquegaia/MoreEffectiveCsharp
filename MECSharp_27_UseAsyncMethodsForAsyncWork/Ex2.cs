using System;
using System.IO;
using System.Threading.Tasks;

namespace MECSharp_27_UseAsyncMethodsForAsyncWork
{
    // page 142, par 2
    public class Ex2
    {
        static string file = @"D:\jsfxr.js";

        public static void Test()
        {
            // sync -----------------------------------------------------------
            //Log("enter sync");
            //int resSync = HandleFile();
            //Log("exit sync");
            //Log(resSync.ToString());
            //Other();

            // async Task<int> ------------------------------------------------
            //Log("enter async");
            //Task<int> asyncWork = HandleFileAsync();
            //Log("Enter something: ");
            //string line = Console.ReadLine();
            //Log("You entered (asynchronous logic): " + line);
            //Log("exit async");
            //asyncWork.Wait();
            //var resAsync = asyncWork.Result;
            //Log(resAsync.ToString());
            //Other();

            // async Task: (void)
            // should fail to report exception when not awaited ---------------
            Log("enter async");
            Task asyncWork2 = HandleFileAsyncVoid();
            Log("Enter something: ");
            string line2 = Console.ReadLine();
            Log("You entered (asynchronous logic): " + line2);
            Log("exit async");
            //asyncWork2.Wait();
            //string resAsync2 = asyncWork2.Exception.Message;
            //Log(resAsync2.ToString());
            Other();
        }

        private static void Other()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log("Continue ...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static async Task<int> HandleFileAsync()
        {
            int count = 0;
            using (StreamReader stream = new StreamReader(file))
            {
                int n = 100_000;
                string v = await stream.ReadToEndAsync();
                count += v.Length;
                for (int i = 0; i < n; i++)
                {
                    int x = v.GetHashCode();
                    //if (i == n - 1)
                    //{
                    //    throw new FieldAccessException("EXCEPTION");
                    //}
                }
            }
            return count;
        }

        static async Task HandleFileAsyncVoid()
        {
            int count = 0;
            using (StreamReader stream = new StreamReader(file))
            {
                int n = 100_000;
                string v = await stream.ReadToEndAsync();
                count += v.Length;
                for (int i = 0; i < n; i++)
                {
                    int x = v.GetHashCode();
                    if (i == n - 1)
                    {
                        throw new FieldAccessException("EXCEPTION");
                    }
                }
            }
        }

        static int HandleFile()
        {
            int count = 0;
            using (StreamReader stream = new StreamReader(file))
            {
                string v = stream.ReadToEnd();
                count += v.Length;
                for (int i = 0; i < 100_000; i++)
                {
                    int x = v.GetHashCode();
                }
            }
            return count;
        }

        private static void Log(string s) => Console.WriteLine($"{DateTime.Now}: {s}");
    }
}
