using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_28_NeverWriteAsyncVoidMethods
{
    class Pg146_1_CustomAwaitableTypes
    {
        public static async void Test()
        {
        }
    }

    class Awaitable
    {
        public Awaiter GetAwaiter() => new Awaiter();

        //public static async void Foo() => await Bar();

        //public static async Awaitable Bar()
        //{
        //    Awaitable awaitable = new Awaitable();
        //    await awaitable;
        //    return awaitable.GetAwaiter();
        //}
    }

    class Awaiter : INotifyCompletion
    {
        public void OnCompleted(Action continuation)
        {
        }

        public bool IsCompleted { get; }
        public void GetResult()
        {
        }
    }
}
