using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.JesseAndCookies
{
    class Program
    {

        static List<int> heap = new List<int>() { int.MinValue } ;

        static int parent (int i) { return i / 2; }
        static int left(int i) {
            var r= 2*i;
            return r >= heap.Count - 1? 0 : r; 
        }
        static int right(int i)
        {
            var r = 2 * i + 1;
            return r >= heap.Count - 1 ? 0 : r;
        }

        static void insert (int val)
        {
            heap.Add(val);

            percolatingUp(heap.Count - 1);
        }

        static int removeRoot()
        {
            int val = heap[1];
            heap[1] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            percolatingDown(1);
            return val;
        }

        private static void percolatingDown(int i)
        {
            var l = left(i);
            var r = right(i);

            if (  i < heap.Count - 1 )
            {
                if ( r == 0 ||  heap[l] < heap[r] )
                {
                    if (l > 0 && heap[l] < heap[i])
                    {
                        swap(l, i);
                        percolatingDown(l);
                    }
                }
                else
                {
                    if (r>0 && heap[r] < heap[i])
                    {
                        swap(l, i);
                        percolatingDown(l);
                    }                    
                }
            }
        }

        private static void swap(int target, int i)
        {
            var t = heap[i];
            heap[i] = heap[target];
            heap[target] = t;
        }

        private static void percolatingUp(int i)
        {            
            int parentIndex = parent(i);

            if (parentIndex >= 1 && heap[i] < heap[parentIndex])
            {
                var t = heap[i];
                heap[i] = heap[parentIndex];
                heap[parentIndex] = t;
                percolatingUp(parentIndex);
            }            
        }

        static void Main(string[] args)
        {
            //int[] arr = new int[] { 1, 2, 3, 9, 10, 12 };

            int K = int.Parse(Console.ReadLine().Split(' ')[1]);
            var arr = Console.ReadLine().Split(' ').Select(i => int.Parse(i));

            foreach (int i in arr)
                insert(i);

            int counter = 0;


            while (heap[1] <= K)
            {
                insert(removeRoot() + removeRoot() * 2);
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}