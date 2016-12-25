using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void testMerge()
        {
            Node root = BuildTree();
            List<int> l = root.ConvertToArray();
            CollectionAssert.AreEqual(new int[] { 52, 14, 37, 91, 42, 10, 13, 3, 29 }, l);
        }

        [Test]
        public void testMergeWithPriority()
        {
            Node root = null;
            Treap.merge(ref root, Treap.init(52), Treap.init(14));
            Treap.merge(ref root, root, Treap.init(37));
            Treap.merge(ref root, root, Treap.init(91));
            Treap.merge(ref root, root, Treap.init(42));
            Treap.merge(ref root, root, Treap.init(10));
            Treap.merge(ref root, root, Treap.init(13));
            Treap.merge(ref root, root, Treap.init(3));
            Treap.merge(ref root, root, Treap.init(29));

            List<int> l = root.ConvertToArray();
            CollectionAssert.AreEqual(new int[] { 52, 14, 37, 91, 42, 10, 13, 3, 29 }, l);
        }

        [Test]
        public void testSplitSimple()
        {
            Node root = null;
            root = Extension.FromArray(1, 2, 3, 4);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4}, root.ConvertToArray());

            Node l = null, r = null;
            Treap.split(2, root, out l, out r);

            CollectionAssert.AreEqual(new int[] { 1 , 2}, l.ConvertToArray());
            CollectionAssert.AreEqual(new int[] { 3, 4 }, r.ConvertToArray());
        }

        [Test]
        public void TestSplitRegression()
        {
              Node root = null;

            var n0 = new Node() { val = 1, prior = 50 };
            var n1 = new Node() { val = 2, prior = 47 };
            var n2 = new Node() { val = 3, prior = 24 };
            var n3 = new Node() { val = 4, prior = 96 };

            Treap.merge(ref root, n0, n1);
            Treap.merge(ref root, root, n2);
            Treap.merge(ref root, root, n3);

            Node l = null, r = null;
            Treap.split(2, root, out l, out r);

            CollectionAssert.AreEqual(new int[] { 1, 2 }, l.ConvertToArray());
            CollectionAssert.AreEqual(new int[] { 3, 4 }, r.ConvertToArray());            
        }

        [Test]
        public void testSplitComplex()
        {
            Node root = BuildTree();            

            Node l = null, r = null;
            Treap.split(6, root, out l, out r);

            CollectionAssert.AreEqual(new int[] { 52, 14, 37, 91, 42, 10 }, l.ConvertToArray());
            CollectionAssert.AreEqual(new int[] { 13, 3, 29 }, r.ConvertToArray());
        }
      
        private static Node BuildTree()
        {
            Node root = null;

            var n0 = new Node() { val = 52, prior = 3 };
            var n1 = new Node() { val = 14, prior = 5 };
            var n2 = new Node() { val = 37, prior = 2 };
            var n3 = new Node() { val = 91, prior = 7 };
            var n4 = new Node() { val = 42, prior = 8 };
            var n5 = new Node() { val = 10, prior = 4 };
            var n6 = new Node() { val = 13, prior = 1 };
            var n7 = new Node() { val = 3, prior = 6 };
            var n8 = new Node() { val = 29, prior = 0 };


            Treap.merge(ref root, n0, n1);
            Treap.merge(ref root, root, n2);
            Treap.merge(ref root, root, n3);
            Treap.merge(ref root, root, n4);
            Treap.merge(ref root, root, n5);
            Treap.merge(ref root, root, n6);
            Treap.merge(ref root, root, n7);
            Treap.merge(ref root, root, n8);
            return root;
        }
    }
}
