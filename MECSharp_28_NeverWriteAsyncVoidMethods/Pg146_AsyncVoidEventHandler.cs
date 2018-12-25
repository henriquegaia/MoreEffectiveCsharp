using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace MECSharp_28_NeverWriteAsyncVoidMethods
{
    class Pg146_2_AsyncVoidEventHandler : Form
    {
        public static void Test()
        {
            Form form = new Form();
            form.Click += new EventHandler(Forget);
            Application.EnableVisualStyles();
            Application.Run(form);
        }

        private static async void Forget(object sender, EventArgs e)
        {
            // -----------------------------------------------------------------
            // ?? pg 148: 
            // how to pass exception as arg if it's generated inside 
            //the extension method?

            //Task task = Bar();
            //task.FireAndForget(LogMessage(ex));
            // -----------------------------------------------------------------

            try
            {
                int n = 2;
                Console.WriteLine($"wait {n} s");
                MessageBox.Show($"waited {n} s");
                Task task = Bar();
                await task;
            }
            catch (Exception ex) when (LogMessage(ex))
            {
            }

            bool LogMessage(Exception exception)
            {
                Log.Exception(exception);
                return false;
            }
        }

        static async Task Bar()
        {
            using (StreamReader sr = new StreamReader("garbage"))
            {
                string v = await sr.ReadToEndAsync();
            }
        }

    }

}
