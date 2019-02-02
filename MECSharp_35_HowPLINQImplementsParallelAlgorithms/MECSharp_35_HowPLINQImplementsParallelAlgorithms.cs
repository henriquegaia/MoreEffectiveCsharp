using System;
using Utilities;

namespace MECSharp_35_HowPLINQImplementsParallelAlgorithms
{
    class MECSharp_35_HowPLINQImplementsParallelAlgorithms
    {
        static void Main(string[] args)
        {
            var data = SampleData.IntCollection(amount: 10, max: 10);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        static void pg178_AsParallel()
        {

        }

    }
}
