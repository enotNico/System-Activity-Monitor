using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Activity_Monitor.Command
{
    public class PressKeyCommand : ICommand
    {
        TitleParser reciever;
        public PressKeyCommand(TitleParser r)
        {
            reciever = r;
        }

        public void Execute()
        {
            //reciever.Active();
        }
    }
}
