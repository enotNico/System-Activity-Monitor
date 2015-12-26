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
using System.Diagnostics;
using System.Runtime.InteropServices; //for dllimport
using System_Activity_Monitor.Command;
using System_Activity_Monitor.Hooks;
using System.Timers;

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
        IntPtr m_hhook;
        bool active;
        public MainWindow()
        {
            InitializeComponent();

            btSelector.Background = Brushes.IndianRed;
            active = false;

            dele = new ChangeWindowHook.WinEventDelegate(WinEventProc);
            //IntPtr m_hhook = ChangeWindowHook.SetWinEventHook(ChangeWindowHook.EVENT_SYSTEM_FOREGROUND, ChangeWindowHook.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, ChangeWindowHook.WINEVENT_OUTOFCONTEXT);
            
            /////////////////////////// KEYHOOKS////////////////////////
            //keyhook = new KeyboardHook();
            //keyhook.KeyboardEvent += new KeyboardHook.KeyboardEventHandler(kEv);
            //keyhook.InstallHook();
            ////////////////////////////////////////////////////////////

            invoker = new Invoker();
            rec = new TitleParser();
}

        
        Stopwatch sw;
        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            sw = new Stopwatch();
            sw.Start();

            invoker.SetCommand(new ChangeActiveWindowCommand(rec, ChangeWindowHook.GetActiveWindowTitle()));
            
            invoker.AcEvent();

            TimeLabel.Content = sw.ElapsedMilliseconds;

            
            

            clist.Items.Add(rec.Title);
            clist.SelectedIndex = clist.Items.Count;
            //log.Text += ChangeWindowHook.GetActiveWindowTitle() + "\r\n";
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //lab.Content = "a";
            //tblock.Text = "Select start: " + tbx.SelectionStart + "Selection Length: " + tbx.SelectionLength + "Content: " + tbx.SelectedText;  
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!active)
            {
                m_hhook = ChangeWindowHook.SetWinEventHook(ChangeWindowHook.EVENT_SYSTEM_FOREGROUND, ChangeWindowHook.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, ChangeWindowHook.WINEVENT_OUTOFCONTEXT);
                btSelector.Background = Brushes.Green;
                
            }
            else
                btSelector.Background = Brushes.IndianRed;
               // m_hhook = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            //tbb.Text = "a";
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
