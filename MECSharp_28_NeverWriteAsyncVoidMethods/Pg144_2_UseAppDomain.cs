using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_28_NeverWriteAsyncVoidMethods
{
    public class Pg144_2_UseAppDomain
    {
        public static void Test()
        {
            FireAndForget();
        }

        static async void FireAndForget()
        {
            AsyncWork();
            ContinueWork();
        }

        private static async void AsyncWork()
        {
            Console.WriteLine("AsyncWork ... before delay");
            Task task = Task.Delay(2000);
            await task;
            Console.WriteLine("AsyncWork ... after delay");
        }

        private static async void ContinueWork()
        {
            Console.WriteLine("continue ... before delay");
            Task task = Task.Delay(2000);
            await task;
            Console.WriteLine("continue ... after delay");
        }
    }

}
