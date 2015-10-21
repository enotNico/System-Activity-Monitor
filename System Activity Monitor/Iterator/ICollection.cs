using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Activity_monitor.Iterator
{
    public interface ICollection
    {
        Iterator CreateIterator();
    }
}
