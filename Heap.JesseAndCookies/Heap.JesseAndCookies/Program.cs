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
        public static int solve(int K, IEnumerable<int> arr)
        {
            MinHeap minHeap = new MinHeap();

            foreach (int i in arr)
                minHeap.Insert(i);

            int counter = 0;

            while (minHeap.MinElement <= K && minHeap.Count >= 3)
            {
                minHeap.Insert(minHeap.RemoveRoot() + minHeap.RemoveRoot() * 2);
                counter++;
            }


            return minHeap.MinElement >= K ? counter : -1;
        }

        static void Main(string[] args)
        {            
            int K = int.Parse(Console.ReadLine().Split(' ')[1]);
            var l = Console.ReadLine().Split(' ').Select(i => int.Parse(i));
            
            int counter = solve(K, l);

            Console.WriteLine(counter);        
        }                       

    }
}