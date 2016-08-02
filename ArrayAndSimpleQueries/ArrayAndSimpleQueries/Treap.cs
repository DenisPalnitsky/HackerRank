using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    [DebuggerDisplay("Index={index}, Val={val}")]
    class Node
    {
        public int index;
        public int prior;
        public int val;

        public Node l;
        public Node r;        
    }

    class Treap
    {        
        static Random randomizer = new Random();

        public static void split(Node t, ref Node l, ref Node r, int key)
        {
            if (t == null)
            {
                l = null;
                r = null;
            }
            else if (t.index <= key)
            {
                split(t.r, ref t.r, ref r, key);
                l = t; //elem=key comes in l
            }
            else
            {
                split(t.l, ref l, ref t.l, key);
                r = t;
            }

        }

        public void merge(ref Node t, Node l, Node r)
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

        public static void insert(ref Node t, Node it)
        {
            if (t == null)
                t = it;
            else if (it.prior > t.prior)
            {
                split(t, ref it.l, ref it.r, it.index);
                t = it;
            }
            else
            {                
                if (t.index <= it.index)
                    insert(ref t.r, it);
                else 
                    insert (ref t.l, it);
            }
        }

        public static Node init(int val, int index)
        {
            Node ret = new Node();
            ret.index = index;
            ret.val = val;
            ret.prior = randomizer.Next();
            return ret;
        }

        public static Node init(int val, int index,  int priority)
        {
            Node ret = new Node();
            ret.index = index;
            ret.val = val;
            ret.prior = priority;
            return ret;
        }

        public static void AddL(ref Node l)
        {
            l = new Node() { index = 5 };
        }

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
                Console.Write("[{0}:{1}],", counter, root.val);
                counter++;
                traverse(root.r, counter);
            }
        }
        
    }
}
