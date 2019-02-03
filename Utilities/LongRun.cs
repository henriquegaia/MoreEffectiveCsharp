namespace Utilities
{
    public static class LongRun
    {
        public static double ComputeValue()
        {
            double d = 0;
            for (int i = 0; i < 10_000_000; i++)
            {
                d += InterimCalculation(i);
            }
            return d;
        }

        private static double InterimCalculation(int i) =>
            i ^ 1;

        public static int Factorial(int d)
        {
            int res = d;
            while (d != 1)
            {
                --d;
                res *= d;
            }
            return res;
        }

        public static int FactorialRecursive(int d)
        {
            return d <= 1
                ? 1
                : d * FactorialRecursive(d - 1);
        }
    }


}
