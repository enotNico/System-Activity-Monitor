using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace System_Activity_monitor.Iterator
{
    public class Processes : ICollection
    {
        private ArrayList _items = new ArrayList();
        public Processes(Process[] p)
        {
            _items.AddRange(p);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
    }
}
