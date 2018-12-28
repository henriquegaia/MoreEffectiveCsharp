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

            SyncOverAsyncDeadlock();
            label1.Text = Log.ThreadCount().ToString();
        }

        static void SyncOverAsyncDeadlock()
        {
            var t = AsyncWork.Simulate();
            t.Wait();
        }
    }
}
