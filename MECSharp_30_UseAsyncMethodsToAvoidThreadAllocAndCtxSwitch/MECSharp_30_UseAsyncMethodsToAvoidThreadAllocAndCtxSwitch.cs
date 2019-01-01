using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_30_UseAsyncMethodsToAvoidThreadAllocAndCtxSwitch
{
    class MECSharp_30_UseAsyncMethodsToAvoidThreadAllocAndCtxSwitch
    {
        static void Main(string[] args)
        {
            // 1. 154_3: async file io uses io completion ports rather than threads
            // 2. 154_3: async web requests use network interrupts rather than threads
            // 3. 154_4: avoid cpu bound async tasks in non gui apps
        }
    }
}
