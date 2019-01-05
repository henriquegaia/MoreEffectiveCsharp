using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Windows;
using Lib = MECSharp_31_AvoidMarshallingContextUnnecess_Lib.MECSharp_31_AvoidMarshallingContextUnnecess_Lib;

namespace MECSharp_31_AvoidMarshallingContextUnnecess_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Lib.RunTests();

            lb.Content = Thread.CurrentContext;
            var dc = Context.DefaultContext;
            lb.Content = dc.ContextID;
        }
    }
}
