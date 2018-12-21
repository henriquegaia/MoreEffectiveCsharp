using System;

namespace MECSharp_25_LimitArrayParamsToParamsArray
{
    class Ex3
    {
        internal static void Exec()
        {
            // 1
            //WriteOutput1(new int[] { 1, 2 });
            WriteOutput1(new string[] { "one", "two" });
            WriteOutput1(new string[] { });
            //WriteOutput1();

            // 2
            WriteOutput2(new int[] { 1, 2 });
            WriteOutput2("one", "two", 1, new Ex3());
            WriteOutput2();
        }

        private static void WriteOutput1(object[] stuff)
        {
            foreach (object o in stuff)
            {
                Console.WriteLine(o);
            }
        }

        private static void WriteOutput2(params object[] stuff)
        {
            foreach (object o in stuff)
            {
                Console.WriteLine(o);
                if (o.GetType().Name.Equals(typeof(int)))
                {
                    int.TryParse(o.ToString(), out int oo);
                }
            }

        }
    }
}
