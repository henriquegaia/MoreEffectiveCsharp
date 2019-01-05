using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utilities;

namespace MECSharp_31_AvoidMarshallingContextUnnecess_Lib
{
    public static class MECSharp_31_AvoidMarshallingContextUnnecess_Lib
    {
        public static async void RunTests()
        {
            // 156_3: what's marshalling ---------------------------------------

            _156_3_WhatIsMarshalling();

            // 156_3: keep track of current ctx --------------------------------
            // Thread.CurrentContext vs Synchronization Context

            //_156_3_KeepTrackOfContext();

            // 156_3: examples of ctx aware and ctx free code
            // 156_4: execute ctx aware code on the wrong context --------------
            // 156_5: ?
            // 157  : code

            string s = await _157_AvoidRunningCtxAwareOnContextFree();

            // 158  : code
        }

        private static async Task<string> _157_AvoidRunningCtxAwareOnContextFree()
        {
            var res = await AsyncAndThreading.ReadFileAsync(true);
            return res;
        }

        public static void _156_3_WhatIsMarshalling()
        {
            ComClass com = new ComClass();
            bool isCom = Marshal.IsComObject(com);
        }

        public static void _156_3_KeepTrackOfContext()
        {
            var ct = Thread.CurrentContext;
            var dc = Context.DefaultContext;
            var syncCtx = SynchronizationContext.Current;
        }
    }

    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    class ComClass
    {

    }
}
