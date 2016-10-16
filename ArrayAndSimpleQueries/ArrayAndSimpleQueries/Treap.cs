using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    [DebuggerDisplay("Val={val}, Prior={prior}")]
    class Node
    {
        //public int index;
        public int prior;
        public int val;
        public int size = 1;
        
        public void recalc()
        {
            size = sizeOf(l) + sizeOf(r) + 1;
        }

        public static int sizeOf(Node treap)
        {
            return treap == null ? 0 : treap.size;
        }

        public Node l;
        public Node r;        
    }

    class Treap
    {

        //public static void split(Node t, ref Node l, ref Node r, int key)
        //{
        //    if (t == null)
        //    {
        //        l = null;
        //        r = null;
        //    }

        //    else if (t.index <= key)
        //    {
        //        split(t.r, ref t.r, ref r, key);
        //        l = t; //elem=key comes in l
        //    }
        //    else
        //    {
        //        split(t.l, ref l, ref t.l, key);
        //        r = t;
        //    }
        //}

        public static void split(int x, Node t, out Node l, out Node r)
        {
            Node newTree = null;
            int curIndex = Node.sizeOf(t.l) + 1;

            if (curIndex <= x)
            {
                if (t.r == null)
                    r = null;
                else
                    split(x - curIndex, t.r, out newTree, out r);
                
                l = new Node()
                {
                    prior = t.prior,
                    val = t.val,
                    l = t.l,
                    r = newTree
                };
             
                l.recalc();
                
            }
            else
            {
                if (t.l == null)
                    l = null;
                else
                     split(x, t.l, out l, out newTree);

                r = new Node 
                {
                 prior = t.prior,
                 val = t.val,
                 l = newTree,
                 r = t.r
                };
                    
                r.recalc();
            }
        }



        public static void merge(ref Node t, Node l, Node r)
        {
            if (l == null || r == null)
                t = l ?? r;
            else if (l.prior > r.prior)
            {
                merge(ref l.r, l.r, r);
                t = l;
            }
            else
            {
                merge(ref r.l, l, r.l);
                t = r;
            }
        }

        public static void add(ref Node root, Node nodeToAdd)
        {
            merge(ref root, root, nodeToAdd);
        }

        //public static void insert(ref Node t, Node it)
        //{
        //    if (t == null)
        //        t = it;
        //    else if (it.prior > t.prior)
        //    {
        //        split(t, ref it.l, ref it.r, it.index);
        //        t = it;
        //    }
        //    else
        //    {                
        //        if (t.index <= it.index)
        //            insert(ref t.r, it);
        //        else 
        //            insert (ref t.l, it);
        //    }
        //}

        static Random randomizer = new Random();
        public static Node init(int val)
        {
            Node ret = new Node();            
            ret.val = val;
            ret.prior = randomizer.Next();
            return ret;
        }

        //public static Node init(int val, int index,  int priority)
        //{
        //    Node ret = new Node();
        //    ret.index = index;
        //    ret.val = val;
        //    ret.prior = priority;
        //    return ret;
        //}

        //public static void AddL(ref Node l)
        //{
        //    l = new Node() { index = 5 };
        //}

        public static void print(Node node)
        {
            traverse(node, 0);
            Console.WriteLine();
        }

        public static void traverse(Node root, int counter)
        {
            if (root != null)
            {                
                traverse(root.l, counter);
                Console.Write("[{0}]",  root.val);
                counter++;
                traverse(root.r, counter);
            }
        }
        
    }
}
