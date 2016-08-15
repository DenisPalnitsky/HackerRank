using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.JesseAndCookies
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public static void TestNoAnswer()
        {
            int[] arr = new int[] { 1, 2, 3 };
            int K = 50;

            Assert.AreEqual(-1, Program.solve(K, arr));
        }


        [Test]
        public static void TestCase1()
        {
            int[] arr = new int[] { 1, 2, 3, 9, 10, 12 };
            int K = 7;

            Assert.AreEqual(2, Program.solve(K, arr));
        }

        [Test]
        public static void TestCase2()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            int K = 27;

            Assert.AreEqual(3, Program.solve(K, arr));
        }

        [Test]
        public static void TestCase3()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            int K = 28;

            Assert.AreEqual(-1, Program.solve(K, arr));
        }


        [Test]
        public static void TestInsert()
        {
            int[] arr = new int[] { 6, 7, 12, 10, 15, 17 };
            MinHeap heap = new MinHeap();

            foreach (int i in arr)
                heap.Insert(i);

            string s = string.Join(",", heap.AsEnumerable());

            heap.Insert(5);

            s = string.Join(",", heap);
            CollectionAssert.AreEqual(
                new int[] { 5, 7, 6, 10, 15, 17, 12 },
                 heap.AsEnumerable());
        }

        [Test]
        public static void TestRemove()
        {
            int[] arr = new int[] { 6, 7, 12, 10, 15, 17 };

            MinHeap heap = new MinHeap();

            foreach (int i in arr)
                heap.Insert(i);

            string s = string.Join(",", heap.AsEnumerable());

            heap.Insert(5);
            Assert.AreEqual(5, heap.RemoveRoot());

            s = string.Join(",", heap.AsEnumerable());

            CollectionAssert.AreEqual(
                new int[] { 6, 7, 12, 10, 15, 17 },
                 heap.AsEnumerable());
        }
    }
}
