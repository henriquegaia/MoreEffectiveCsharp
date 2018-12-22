using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_28_NeverWriteAsyncVoidMethods
{
    public class Pg144_2_UseAppDomain
    {
        static readonly string file = @"D:\jsfxr.js";

        public static void Test()
        {
            // case 1: can catch exception ------------------------------------
            // async Task<int> ------------------------------------------------

            ExceptionCaught();

            // case 2: can't catch or log exception ---------------------------
            // async void -----------------------------------------------------

            //ExceptionNotCatchedOrThrown();

            // case 3: can't catch exception but can log it -------------------
            // async void -----------------------------------------------------

            //AppDomainThrowsException();
        }

        private static void ExceptionCaught()
        {
            try
            {
                Log("enter async");
                Task<int> asyncWork = HandleFileAsync();
                Log("Enter something: ");
                string line = Console.ReadLine();
                Log("You entered (asynchronous logic): " + line);
                Log("exit async");
                asyncWork.Wait();
                var resAsync = asyncWork.Result;
                Log(resAsync.ToString());
                Other();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ExceptionNotCatchedOrThrown()
        {
            try
            {
                Log("enter async");
                HandleFileAsyncVoid();
                Log("Enter something: ");
                string line2 = Console.ReadLine();
                Log("You entered (asynchronous logic): " + line2);
                Log("exit async");
                Other();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AppDomainThrowsException()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(e.ExceptionObject.ToString());
            };

            Log("enter async");
            HandleFileAsyncVoid();
            Log("Enter something: ");
            string line2 = Console.ReadLine();
            Log("You entered (asynchronous logic): " + line2);
            Log("exit async");
            Other();
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
                    if (i == n - 1)
                    {
                        throw new FieldAccessException("EXCEPTION");
                    }
                }
            }
            return count;
        }

        static async void HandleFileAsyncVoid()
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

        private static void Other()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log("Continue ...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Log(string s) => Console.WriteLine($"{DateTime.Now}: {s}");
    }
}
