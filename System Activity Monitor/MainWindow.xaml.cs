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
using System.Windows.Forms;
using Kennedy.ManagedHooks;
using System.Runtime.InteropServices; //for dllimport
using System_Activity_Monitor.Command;
using System_Activity_Monitor.Hooks;

namespace System_Activity_Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      //  private KeyboardHook keyhook = null;
        Invoker invoker;
        TitleParser rec;

        ChangeWindowHook.WinEventDelegate dele = null;
        public MainWindow()
        {
            

            dele = new ChangeWindowHook.WinEventDelegate(WinEventProc);
            IntPtr m_hhook = ChangeWindowHook.SetWinEventHook(ChangeWindowHook.EVENT_SYSTEM_FOREGROUND, ChangeWindowHook.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, ChangeWindowHook.WINEVENT_OUTOFCONTEXT);
            
            /////////////////////////// KEYHOOKS////////////////////////
            //keyhook = new KeyboardHook();
            //keyhook.KeyboardEvent += new KeyboardHook.KeyboardEventHandler(kEv);
            //keyhook.InstallHook();
            ////////////////////////////////////////////////////////////

            invoker = new Invoker();
            rec = new TitleParser();

            InitializeComponent();
        }

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            invoker.SetCommand(new ChangeActiveWindowCommand(rec, ChangeWindowHook.GetActiveWindowTitle()));
            invoker.AcEvent();

            //windowlist.Items.Add(rec.Title);  
            //log.Text += ChangeWindowHook.GetActiveWindowTitle() + "\r\n";
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //lab.Content = "a";
            //tblock.Text = "Select start: " + tbx.SelectionStart + "Selection Length: " + tbx.SelectionLength + "Content: " + tbx.SelectedText;  
        }


        //private void kEv(KeyboardEvents kEvent, Keys key)
        //{
        //    invoker.AcEvent();
        //}

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
