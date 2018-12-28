using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class AsyncWork
    {
        public static async Task Simulate() =>
            await Task.Delay(1000);

    }
}
