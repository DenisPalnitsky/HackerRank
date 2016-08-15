using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.JesseAndCookies
{
    class MinHeap
    {
        List<int> _heap = new List<int>() { int.MinValue };

        public int MinElement
        {
            get
            {
                return _heap[1];
            }
        }

        public int Count
        {
            get { return _heap.Count;  }
        }

        public void Insert(int val)
        {
            _heap.Add(val);

            percolatingUp(_heap.Count - 1);
        }

        public int RemoveRoot()
        {
            int val = _heap[1];
            _heap[1] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            percolatingDown(1);
            return val;
        }

        int parent(int i) { return i / 2; }

        int left(int i)
        {
            var r = 2 * i;
            return r >= _heap.Count ? 0 : r;
        }

        int right(int i)
        {
            var r = 2 * i + 1;
            return r >= _heap.Count ? 0 : r;
        }

        private void percolatingDown(int i)
        {
            var l = left(i);
            var r = right(i);

            if (i < _heap.Count - 1)
            {
                if (r == 0 || _heap[l] < _heap[r])
                {
                    if (l > 0 && _heap[l] < _heap[i])
                    {
                        swap(l, i);
                        percolatingDown(l);
                    }
                }
                else
                {
                    if (r > 0 && _heap[r] < _heap[i])
                    {
                        swap(r, i);
                        percolatingDown(r);
                    }
                }
            }
        }

        private void swap(int target, int i)
        {
            var t = _heap[i];
            _heap[i] = _heap[target];
            _heap[target] = t;
        }

        private void percolatingUp(int i)
        {
            int parentIndex = parent(i);

            if (parentIndex >= 1 && _heap[i] < _heap[parentIndex])
            {
                var t = _heap[i];
                _heap[i] = _heap[parentIndex];
                _heap[parentIndex] = t;
                percolatingUp(parentIndex);
            }
        }

        internal System.Collections.IEnumerable AsEnumerable()
        {
            return _heap.Skip(1);
        }
    }
}
