using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class myList<T> : IList<T>
    {
        private int _count = 0;
        private int capacity = 8;
        private T[] coll;

        public myList() {
            coll = new T[capacity];
        }

        public T this[int index] { get => coll[index]; set { coll[index] = value; } }

        public int Count { get => _count; }

        public bool IsReadOnly {get => false;}

        public bool IsFixedSize { get => false; }

        public bool IsSynchronized { get => false; }

        public object SyncRoot { get => this; }

        public void Add(T item)
        {
            _count++;
            if (_count >= capacity) {
                int old_cap = capacity;
                capacity += 8;
                T[] tmp = coll;
                coll = new T[capacity];
                coll.CopyTo(tmp, old_cap);
            }
            coll[_count-1] = item;

        }

        public void Clear()
        {
            _count = 0;
            coll = new T[capacity];
        }

        public bool Contains(T item)
        {
            bool isCont = false;
            foreach (var tmp in coll)
                if (tmp.Equals(item))
                {
                    isCont = true;
                    break;
                }
            return isCont;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = arrayIndex;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(coll[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            while (index < _count)
                yield return coll[index++];
        }

        public int IndexOf(T item)
        {   
            int index = -1;
            for (int i = 0; i < _count + 1; i++)
            {
                if (coll[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            if (!(index >= 0 && index <= _count))
                return;
            _count++;

            for (int i = _count - 1; i > index; i--)
            {
                coll[i] = coll[i - 1];
            }
            coll[index] = item;
        }

        public bool Remove(T item)
        {   
            int index = IndexOf(item);
            if (!(index >= 0) && (index < Count))
                return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (!(index >= 0) && (index < Count))
                return;
            for (int i = index; i < Count - 1; i++)
            {
                coll[i] = coll[i + 1];
            }
            _count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
