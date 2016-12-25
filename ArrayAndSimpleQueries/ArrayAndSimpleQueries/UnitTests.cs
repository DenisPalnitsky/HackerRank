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
            List<int> l = root.ToArray();
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

            List<int> l = root.ToArray();
            CollectionAssert.AreEqual(new int[] { 52, 14, 37, 91, 42, 10, 13, 3, 29 }, l);
        }

        [Test]
        public void testSplitSimple()
        {
            Node root = null;
            root = Extension.FromArray(1, 2, 3, 4);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4}, root.ToArray());

            Node l = null, r = null;
            Treap.split(2, root, out l, out r);

            CollectionAssert.AreEqual(new int[] { 1 , 2}, l.ToArray());
            CollectionAssert.AreEqual(new int[] { 3, 4 }, r.ToArray());
        }

        [Test]
        public void TestSplitRegression()
        {
              Node root = null;

            var n0 = new Node() { val = 0, prior = 50 };
            var n1 = new Node() { val = 1, prior = 47 };
            var n2 = new Node() { val = 2, prior = 24 };
            var n3 = new Node() { val = 3, prior = 96 };

            Treap.merge(ref root, n0, n1);
            Treap.merge(ref root, root, n2);
            Treap.merge(ref root, root, n3);

            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3 }, root.ToArray());


            Treap.traverse(root, 0, n => n.recalc());

            Node l = null, r = null;
            Treap.split(2, root, out l, out r);

            CollectionAssert.AreEqual(new int[] { 0, 1 }, l.ToArray());
            CollectionAssert.AreEqual(new int[] { 2, 3 }, r.ToArray());            
        }

        [Test]
        public void testSplitComplex()
        {
            Node root = BuildTree();            

            Node l = null, r = null;
                        
            Treap.split(6, root, out l, out r);

            CollectionAssert.AreEqual(new int[] { 52, 14, 37, 91, 42, 10 }, l.ToArray());
            CollectionAssert.AreEqual(new int[] { 13, 3, 29 }, r.ToArray());
        }
      

        [Test]
        public void PerforQuery1()
        {
            Node root = null;
            root = Extension.FromArray(1, 2, 3);
            Program.performQuery(ref root, new Query(1, 1, 1));

            CollectionAssert.AreEqual(new [] { 2,1,3}, root.ToArray());
        }


        [Test]
        public void PerforQuery2()
        {
            Node root = null;
            root = Extension.FromArray(1, 2, 3);
            Program.performQuery(ref root, new Query(2, 1, 1));

            CollectionAssert.AreEqual(new[] {  1, 3, 2 }, root.ToArray());
        }

        [Test]
        public void PerforQuery1Regression()
        {
            Node root = null;
            root = Extension.FromArray(1, 2, 3, 4, 5, 6, 7, 8);
            Program.performQuery(ref root, new Query(1, 2, 4));

            CollectionAssert.AreEqual(new[] { 2, 3, 4, 1, 5, 6, 7, 8 }, root.ToArray());
        }
        //

        [Test]
        public void PerforQuery2Regression()
        {
            Node root = null;
            root = Extension.FromArray(1,2,3,4,5,6,7,8);
            Program.performQuery(ref root, new Query(2, 3, 5));

            CollectionAssert.AreEqual(new[] { 1, 2, 6, 7, 8, 3, 4, 5 }, root.ToArray());
        }

        [Test]
        public void SplitRegression2()
        {
            Node root,l,r = null;
            root = Extension.FromArray(1, 2, 3, 4);
            Treap.split(3, root, out l, out r);

            CollectionAssert.AreEqual(new[] { 4 }, r.ToArray());
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
