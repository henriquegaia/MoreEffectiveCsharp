using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace MECSharp_29_AvoidComposingSyncAndAsyncMethods_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SyncOverAsyncDeadlock();
            SyncOverAsyncDeadlock_Resolved_TimeOut();
            //await SetNumberOfThreads_NonBlocking();
        }

        // ---------------------------------------------------------------------

        void SyncOverAsyncDeadlock()
        {
            var t = AsyncWork.Simulate();
            t.Wait();
        }

        void SyncOverAsyncDeadlock_Resolved_TimeOut()
        {
            int timeout = 2;
            label1.Text = $"unresponsive for {timeout} seconds";
            var t = AsyncWork.Simulate();
            t.Wait(TimeSpan.FromSeconds(timeout));
            label1.Text = $"responsive again";
        }

        async Task SyncOverAsyncDeadlock_Resolved_v1()
        {
            await AsyncWork.Simulate(3);
        }

        // ---------------------------------------------------------------------

        private async Task SetNumberOfThreads_NonBlocking()
        {
            label1.Text = "button clicked ... wait 3 sec";
            await SyncOverAsyncDeadlock_Resolved_v1();
            label1.Text = Log.ThreadCount().ToString();
        }

    }
}
