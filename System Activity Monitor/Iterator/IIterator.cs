using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace System_Activity_monitor.Iterator
{
    public interface IIterator
    {
        Process First();
        Process Next();
        bool IsDone();
        Process CurrentItem();
    }
}
