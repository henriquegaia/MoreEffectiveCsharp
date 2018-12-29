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

        static void SyncOverAsyncDeadlock()
        {
            var t = AsyncWork.Simulate();
            t.Wait();
        }

        static async Task SyncOverAsyncDeadlock_Resolved()
        {
            await AsyncWork.Simulate_3();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await SyncOverAsyncDeadlock_Resolved();
            label1.Text = Log.ThreadCount().ToString();
        }
    }
}
