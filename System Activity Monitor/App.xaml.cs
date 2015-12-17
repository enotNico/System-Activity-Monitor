using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System_Activity_Monitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int WHKEYBOARDLL = 13;



        private LowLevelKeyboardProcDelegate mcallback;
        private IntPtr mhhook;

        private delegate IntPtr LowLevelKeyboardProcDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        public void SetHook()
        {
            mcallback = LowLevelKeyboardHookProc;
            mhhook = SetWindowsHookEx(WHKEYBOARDLL, mcallback, GetModuleHandle(IntPtr.Zero), 0);
        }

        public void Unhook()
        {
            UnhookWindowsHookEx(mhhook);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, IntPtr hMod, int dwThreadId);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(IntPtr lpModuleName);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int code, IntPtr wparam, IntPtr lparam);

        private IntPtr LowLevelKeyboardHookProc(int code, IntPtr wparam, IntPtr lparam)
        {
            if (code < 0)
            {
                return CallNextHookEx(mhhook, code, wparam, lparam);
            }
            else
            {
                var khs = (KeyboardHookStruct)Marshal.PtrToStructure(lparam, typeof(KeyboardHookStruct));

                Debug.Print("Code-{0},WParam:{1},{2},{3},{4}", code, wparam, lparam, khs.VirtualKeyCode, khs.ScanCode, khs.Flags, khs.Time);
                MessageBox.Show(string.Format("Code-{0},WParam:{1},{2},{3},{4}", code, wparam, lparam, khs.VirtualKeyCode, khs.ScanCode, khs.Flags, khs.Time));
                Debug.Print(khs.VirtualKeyCode.ToString());
                MessageBox.Show(khs.VirtualKeyCode.ToString());

                // alt tab
                if (khs.VirtualKeyCode == 9 &&
                    lparam.ToInt32() == 260 &&
                    khs.ScanCode == 15)
                {
                    System.Console.WriteLine("Alt+Tab pressed!");
                    IntPtr val = new IntPtr(1);
                    return val;
                }
                else
                {
                    return CallNextHookEx(mhhook, code, wparam, lparam);
                }
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct KeyboardHookStruct
        {
            public readonly int VirtualKeyCode;
            public readonly int ScanCode;
            public readonly int Flags;
            public readonly int Time;
            public readonly IntPtr ExtraInfo;
        }
    }
}
