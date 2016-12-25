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


        // merge works fine
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
     
        static Random randomizer = new Random();
        public static Node init(int val)
        {
            Node ret = new Node();            
            ret.val = val;
            ret.prior = randomizer.Next(100);
            return ret;
        }
        

        public static void print(Node node)
        {
            traverse(node, 0, root => Console.Write("[{0}]",  root.val));
            Console.WriteLine();
        }



        public static void traverse(Node root, int counter, Action<Node> act)
        {
            if (root != null)
            {                
                traverse(root.l, counter, act);
                act(root);
                counter++;
                traverse(root.r, counter, act);
            }
        }
        
    }


    static class  Extension {
        
        public static List<int> ToArray(this Node root)
        {
            List<int> l = new List<int>();
            Treap.traverse(root, 0, n => l.Add(n.val));
            return l;
        }

        public static string ToArrayString(this Node root)
        {
            return String.Join(" ", root.ToArray()); 
        }

        public static Node FromArray(params int[] a)
        {                       
            Node root = null;
                         
            Treap.merge(ref root,  Treap.init(a.First()), Treap.init(a.Skip(1).First()));

            foreach (var n in a.Skip(2))
            {
                Treap.merge(ref root, root, Treap.init(n));
            }

            root.recalc();
            return root;
        }
    }

}
