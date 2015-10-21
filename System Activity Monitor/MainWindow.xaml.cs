using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace System_Activity_Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //public List<string> ProcessesList()
        //{
        //    List<string> st = new List<string>();

        //    Processes processes = new Processes(System.Diagnostics.Process.GetProcesses());
        //    Iterator.Iterator pIterator = new Iterator.Iterator(processes);

        //    for (System.Diagnostics.Process i = pIterator.First(); !pIterator.IsDone(); i = pIterator.Next())
        //    {
        //        st.Add(i.ProcessName);
        //    }
        //    return st;
        //}

    }
}
