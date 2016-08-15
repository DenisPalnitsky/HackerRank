using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.JesseAndCookies
{
    [TestFixture]
    public class Program
    {
        static List<int> heap = new List<int>() { int.MinValue } ;

        static int parent (int i) { return i / 2; }
        
        static int left(int i) {
            var r = 2*i;
            return r >= heap.Count ? 0 : r; 
        }
        
        static int right(int i)
        {
            var r = 2 * i + 1;
            return r >= heap.Count  ? 0 : r;
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
                        swap(r, i);
                        percolatingDown(r);
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

        private static int solve(int K, IEnumerable<int> arr)
        {
            foreach (int i in arr)
                insert(i);

            int counter = 0;

            while (heap[1] <= K && heap.Count >= 3)
            {
                insert(removeRoot() + removeRoot() * 2);
                counter++;
            }


            return heap[1] >= K ? counter : -1;
        }

        static void Main(string[] args)
        {            
            int K = int.Parse(Console.ReadLine().Split(' ')[1]);
            var l = Console.ReadLine().Split(' ').Select(i => int.Parse(i));
            
            int counter = solve(K, l);

            Console.WriteLine(counter);        
        }
               

        #region Tests

        [Test]
        public static void TestNoAnswer()
        {
            int[] arr = new int[] { 1, 2, 3};
            int K = 50;

            Assert.AreEqual(-1, solve(K, arr));                
        }


        [Test]
        public static void TestCase1()
        {
            int[] arr = new int[] { 1, 2, 3, 9, 10, 12 };
            int K = 7;
                        
            Assert.AreEqual(2, solve(K, arr));
        }

        [Test]
        public static void TestCase2()
        {
            int[] arr = new int[] { 1, 2, 3, 4};
            int K = 27;

            Assert.AreEqual(3, solve(K, arr));
        }

        [Test]
        public static void TestCase3()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            int K = 28;

            Assert.AreEqual(-1, solve(K, arr));
        }


        [Test]
        public static void TestInsert()
        {
            int[] arr = new int[] { 6, 7, 12, 10, 15, 17 };

            foreach (int i in arr)
                insert(i);

            string s = string.Join(",", heap.Skip(1));

            insert(5);

            s = string.Join(",", heap.Skip(1));
            CollectionAssert.AreEqual(
                new int[] { 5,7,6,10,15,17,12 },
                 heap.Skip(1));
        }

        [Test]
        public static void TestRemove()
        {
            int[] arr = new int[] { 6, 7, 12, 10, 15, 17 };

            foreach (int i in arr)
                insert(i);

            string s = string.Join(",", heap.Skip(1));

            insert(5);
            Assert.AreEqual(5, removeRoot());

            s = string.Join(",", heap.Skip(1));
            
            CollectionAssert.AreEqual(
                new int[] { 6,7,12,10,15,17},
                 heap.Skip(1));
        }

        #endregion

    }
}