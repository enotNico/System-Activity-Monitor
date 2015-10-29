using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Activity_Monitor.Command
{
    public class Invoker
    {
        private ICommand _command;

        public Invoker()
        {
            this._command = new NoCommand();
        }

        public void SetCommand(ICommand command)
        {
            this._command = command;
        }
    }
}
