using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MECSharp_20_HowEventsIncreaseCoupling
{
    class MECSharp_20_HowEventsIncreaseCoupling
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Coupled");
            Console.WriteLine();
            AdderCoupled.Exec();
        }
    }

    #region book example

    //class WorkerEventArgs : EventArgs
    //{
    //    public int Percent { get; set; }
    //    public bool Cancel { get; private set; }

    //    public void RequestCancel() => Cancel = true;
    //}

    //class CoupledWorkerEngine
    //{
    //    private static Random random = new Random();
    //    public event EventHandler<WorkerEventArgs> OnProgress;

    //    public void DoLotsOfWork()
    //    {
    //        for (int i = 0; i < 100; i++)
    //        {
    //            SomeWork();
    //            WorkerEventArgs args = new WorkerEventArgs();
    //            args.Percent = i;
    //            OnProgress?.Invoke(this, args);
    //            if (args.Cancel)
    //            {
    //                return;
    //            }
    //        }
    //    }

    //    private void SomeWork()
    //    {
    //        int n = random.Next(1, 4);
    //        Thread.Sleep(TimeSpan.FromSeconds(n));
    //    }
    //}

    //class Subs
    //{
    //    public int Id { get; set; }
    //}
    #endregion



}
