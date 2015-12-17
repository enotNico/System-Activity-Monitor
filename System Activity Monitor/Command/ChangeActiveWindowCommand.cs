using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Activity_Monitor.Command
{
    class ChangeActiveWindowCommand : ICommand
    {
        TitleParser parser;
        string windowTitle;
        public ChangeActiveWindowCommand(TitleParser reciever, string title)
        {
            parser = reciever;
            windowTitle = title;
        }
        public void Execute()
        {
            parser.ParseTitle(windowTitle);
        }
    }
}