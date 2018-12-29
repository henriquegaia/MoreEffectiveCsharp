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
    }


}
