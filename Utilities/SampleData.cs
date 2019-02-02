using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public static class SampleData
    {
        private static Random random = new Random();

        public static IEnumerable<int> IntCollection(int amount=100_00, int max = 200)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return random.Next(1, max);
            }
        }
    }
}
