using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MECSharp_31_AvoidMarshallingContextUnnecess
{
    class MECSharp_31_AvoidMarshallingContextUnnecess
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentContext);
        }
    }
}
