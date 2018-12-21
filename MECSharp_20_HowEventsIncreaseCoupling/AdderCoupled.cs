using System;

namespace MECSharp_20_HowEventsIncreaseCoupling
{

    #region Adder example - with coupling

    public class AdderCoupled
    {
        public static void Exec()
        {
            int iAnswer;
            Adder a = new Adder();
            Adder b = new Adder();
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;
            b.OnMultipleOfFiveReached += a_MultipleOfFiveReached;

            for (int i = 0; i < 10; i++)
            {
                iAnswer = a.Add(1, i);
                Console.WriteLine("a:iAnswer = {0}", iAnswer);
            }

            Console.WriteLine("-> a unsubscribes !! which makes b also unsubscribe ... they are coupled.");
            a.OnMultipleOfFiveReached -= a_MultipleOfFiveReached;

            for (int i = 0; i < 10; i++)
            {
                iAnswer = a.Add(1, i);
                Console.WriteLine("b:iAnswer = {0}", iAnswer);
            }

            Console.ReadKey();
        }

        static void a_MultipleOfFiveReached(object sender, MultipleOfFiveEventArgs e)
        {
            Console.WriteLine("Multiple of five reached: ", e.Total);
        }
    }

    public class Adder
    {
        public event EventHandler<MultipleOfFiveEventArgs> OnMultipleOfFiveReached;
        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
            { OnMultipleOfFiveReached(this, new MultipleOfFiveEventArgs(iSum)); }
            return iSum;
        }
    }

    public class MultipleOfFiveEventArgs : EventArgs
    {
        public MultipleOfFiveEventArgs(int iTotal)
        { Total = iTotal; }
        public int Total { get; set; }
    }

    #endregion
}
