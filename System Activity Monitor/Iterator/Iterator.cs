using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace System_Activity_monitor.Iterator
{
    public class Iterator : IIterator
    {
        private Processes _items;
        private int _current = 0;
        private int _step = 1;

        public Iterator(Processes collection)
        {
            this._items = collection;
        }

        public Process First()
        {
            _current = 0;
            return _items[_current] as Process;
        }

        public Process Next()
        {
            _current += _step;
            if (!IsDone())
                return _items[_current] as Process;
            return null;
        }

        public bool IsDone()
        {
            return _current >= _items.Count;
        }

        public Process CurrentItem()
        {
            return _items[_current] as Process;
        }
        public int Count
        {
            get { return _items.Count; }
        }
    }
}
