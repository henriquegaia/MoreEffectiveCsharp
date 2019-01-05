using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;

namespace MECSharp_31_AvoidMarshallingContextUnnecess_Lib
{
    public static class MECSharp_31_AvoidMarshallingContextUnnecess_Lib
    {
        public static void RunTests()
        {
            // 156_3: what's marshalling ---------------------------------------

            WhatIsMarshalling();

            // 156_3: keep track of current ctx --------------------------------
            // Thread.CurrentContext vs Synchronization Context

            KeepTrackOfContext();

            // 156_3: examples of ctx aware and ctx free code
            // 156_4: execute ctx aware code on the wrong context --------------
            // 156_5: ?
            // 157  : code
            // 158  : code
        }

        public static void WhatIsMarshalling()
        {
            ComClass com = new ComClass();
            bool isCom = Marshal.IsComObject(com);
        }

        public static void KeepTrackOfContext()
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
