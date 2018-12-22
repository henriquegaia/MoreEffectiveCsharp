using System;
using System.IO;
using System.Threading.Tasks;
using Utilities;

namespace MECSharp_28_NeverWriteAsyncVoidMethods
{
    public class Pg144_2_UseAppDomain
    {
        static readonly string file = @"D:\jsfxr.js";

        public static void Test()
        {
            Console.ForegroundColor = ConsoleColor.White;

            // case 1: can catch exception ------------------------------------
            // async Task<int> ------------------------------------------------

            //ExceptionCaught();

            // case 2: can't catch or log exception ---------------------------
            // async void -----------------------------------------------------

            //ExceptionNotCatchedOrThrown();

            // case 3: can't catch exception but can log it -------------------
            // async void -----------------------------------------------------

            AppDomainThrowsException();
        }

        private static void ExceptionCaught()
        {
            try
            {
                Log.Line("enter async");
                Task<int> asyncWork = HandleFileAsync();
                Log.Line("Enter something: ");
                string line = Console.ReadLine();
                Log.Line("You entered (asynchronous logic): " + line);
                Log.Line("exit async");
                asyncWork.Wait();
                var resAsync = asyncWork.Result;
                Log.Line(resAsync.ToString());
                Log.Info();
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
                Log.Line("enter async");
                HandleFileAsyncVoid();
                Log.Line("Enter something: ");
                string line2 = Console.ReadLine();
                Log.Line("You entered (asynchronous logic): " + line2);
                Log.Line("exit async");
                Log.Info();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AppDomainThrowsException()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(e.ExceptionObject.ToString());
                };

                Log.Line("enter async");
                HandleFileAsyncVoid();
                Log.Line("Enter something: ");
                string line2 = Console.ReadLine();
                Log.Line("You entered (asynchronous logic): " + line2);
                Log.Line("exit async");
                Log.Info();
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
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
    }
}
