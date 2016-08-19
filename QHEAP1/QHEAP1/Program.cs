using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHEAP1
{
    class Program
    {
        class MinHeap
        {
            List<int> _heap = new List<int>();

            public int MinElement
            {
                get
                {
                    return _heap.Count > 0 ? _heap[0] : 0;
                }
            }

            public int Count
            {
                get { return _heap.Count; }
            }

            public void Insert(int val)
            {
                _heap.Add(val);

                percolatingUp(_heap.Count - 1);
            }

            public int RemoveRoot()
            {
                int val = _heap[0];
                _heap[0] = _heap[_heap.Count - 1];
                _heap.RemoveAt(_heap.Count - 1);
                percolatingDown(1);
                return val;
            }

            public int Remove (int val)
            {
                var i = findElement(val);
                
                _heap[i] = _heap[_heap.Count - 1];
                _heap.RemoveAt(_heap.Count - 1);
                percolatingDown(i);
                return val;
            }

            private int findElement(int val)
            {
                return _heap.IndexOf(val);
            }

            int parent(int i) { return i / 2; }

            int left(int i)
            {
                var r = 2 * i + 1;
                return r >= _heap.Count ? -1 : r;
            }

            int right(int i)
            {
                var r = 2 * i + 2;
                return r >= _heap.Count  ? -1 : r;
            }

            private void percolatingDown(int i)
            {
                var l = left(i);
                var r = right(i);

                if (i < _heap.Count - 1)
                {
                    if (r == -1 || _heap[l] < _heap[r])
                    {
                        if (l >= 0 && _heap[l] < _heap[i])
                        {
                            swap(l, i);
                            percolatingDown(l);
                        }
                    }
                    else
                    {
                        if (r >= 0 && _heap[r] < _heap[i])
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

                if (parentIndex >= 0 && _heap[i] < _heap[parentIndex])
                {
                    var t = _heap[i];
                    _heap[i] = _heap[parentIndex];
                    _heap[parentIndex] = t;
                    percolatingUp(parentIndex);
                }
            }

            internal IEnumerable<int> AsEnumerable()
            {
                return _heap;
            }
        }

        static void Main(string[] args)
        {
            testc();
            testc2();
            testc3();
            Console.WriteLine("Done");
            Console.ReadKey();

            MinHeap heap = new MinHeap();
            int N = ReadIntArrayFormInput()[0];
            for (int i = 0; i < N; i++)
            {
                var input = ReadIntArrayFormInput();
                switch (input[0])
                {
                    case 1:
                        heap.Insert(input[1]);
                        break;

                    case 2:
                        heap.Remove(input[1]);
                        break;

                    case 3:
                        Console.WriteLine(heap.MinElement);
                        break;
                }
            }


        }

        private static int[] ReadIntArrayFormInput()
        {
            return Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        public static void testc()
        {
            MinHeap heap = new MinHeap();
            heap.Insert(4);
            heap.Insert(9);
            Console.WriteLine(heap.MinElement);
            heap.Remove(4);
            Console.WriteLine(heap.MinElement);
        }

        public static void testc2()
        {
            Console.WriteLine("Test 2");

            MinHeap heap = new MinHeap();
            heap.Insert(4);
            heap.Insert(9);
            heap.Insert(5);
            heap.Insert(7);
            heap.Insert(10);
            Console.WriteLine(heap.MinElement);
            heap.Remove(10); if (heap.AsEnumerable().Contains(10)) throw new Exception("Fail");
            heap.Remove(7); if (heap.AsEnumerable().Contains(7)) throw new Exception("Fail");
            heap.Remove(5); if (heap.AsEnumerable().Contains(5)) throw new Exception("Fail");
            heap.Remove(4); if (heap.AsEnumerable().Contains(4)) throw new Exception("Fail");
            heap.Remove(9); if (heap.AsEnumerable().Contains(4)) throw new Exception("Fail");
            Console.WriteLine(heap.MinElement);
        }

        public static void testc3()
        {
            Console.WriteLine("Test 2");
            Random r = new Random();
            List<int> l = new List<int>();

            for (int i = 0; i < 10000; i++)
                l.Add(r.Next());

            MinHeap heap = new MinHeap();
            foreach(var i in l)
                heap.Insert(i);
            
            Console.WriteLine(heap.MinElement);

            foreach (var i in l)
            { heap.Remove(i); if (heap.AsEnumerable().Contains(i)) throw new Exception("Fail"); }

            
            Console.WriteLine(heap.MinElement);
        }
    }
}
