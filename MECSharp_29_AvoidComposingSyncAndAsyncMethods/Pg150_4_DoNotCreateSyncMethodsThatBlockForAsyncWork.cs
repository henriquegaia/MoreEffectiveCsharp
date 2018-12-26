using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace MECSharp_29_AvoidComposingSyncAndAsyncMethods
{
    class Pg150_4_DoNotCreateSyncMethodsThatBlockForAsyncWork : ITestable
    {
        static Dictionary<int, int> Operations = new Dictionary<int, int>()
        {
            [0] = 2,
            [1] = 4
        };

        // ---------------------------------------------------------------------
        // reasons for not composing sync over async
        // 1- diff exception semantics
        // 2- deadlocks
        // 3- resource consumption
        // ---------------------------------------------------------------------

        public void Test()
        {
            Reason1();
            //Reason2();
            //Reason3();
        }

        // ---------------------------------------------------------------------

        private async void Reason1()
        {
            //Console.WriteLine("Reason 1: diff excep semantics");
            //int resAsync = await ComputeAsync();
            //Console.WriteLine($"res async: {resAsync}");

            int resSync = ComputeSync();
            Console.WriteLine($"res Sync: {resSync}");
        }

        private int ComputeSync()
        {
            throw new NotImplementedException();
        }

        static async Task<int> ComputeAsync()
        {
            try
            {
                var a = await GetOpByIndex(0);
                var b = await GetOpByIndex(1);
                var c = await GetOpByIndex(2);
                return a + b + c;
            }
            catch (KeyNotFoundException e)
            {
                Log.Exception(e);
                return 0;
            }
        }

        private static async Task<int> GetOpByIndex(int v)
        {
            //await Task.Delay(500);
            var op = Operations[v];
            return op;
        }

        // ---------------------------------------------------------------------


        private void Reason2()
        {
            Console.WriteLine("Reason 2: deadlocks");
            throw new NotImplementedException();
        }

        private void Reason3()
        {
            Console.WriteLine("Reason 3: resource consumption");
            throw new NotImplementedException();
        }
    }
}
