using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    [DebuggerDisplay("Val={val}, cnt = {cnt}")]
    class Node
    {
        
        public int prior;
        public int val;

        public bool rev;
                
        public Node l;
        public Node r;

        public int cnt;    
    }

    class Treap
    {        

        static Random randomizer = new Random();

        static int cnt (Node node)
        {
            return node == null ? 0 : node.cnt;
        }

        void upd_cnt(Node node)
        {
            if (node != null)
                node.cnt = cnt(node.l) + cnt(node.r) + 1;
        }
     

        public static void split(Node t, ref Node l, ref Node r, int pos, int add = 0)
        {
            if (t == null)
            {
                l = null;
                r = null;
                return;
            }

            push(t);
            int curr_pos = add + cnt(t.l);

            if (pos <= curr_pos)
            {
                split(t.l, ref l, ref t.l, pos, add);
                r = t; //elem=key comes in l
            }
            else
            {
                split(t.r, ref t.r, ref r, pos, add + 1 + cnt(t.l));
                l = t;
            }

        }

        public static void merge(ref Node t, Node l, Node r)
        {
            push(l);
            push(r);

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
            upd_cnt(t);
        }
       
        public static void push(Node it)
        {
            if (it!=null && it.rev)
            {
                it.rev = false;

                Node tmp = it.l;

                it.r = it.l;
                it.l = tmp;

                if (it.l!=null) it.l.rev ^= true;
                if (it.r!=null) it.r.rev ^= true;
            }
        }

        public static Node init(int val)
        {
            Node ret = new Node();            
            ret.val = val;
            ret.prior = randomizer.Next();
            return ret;
        }

        public static Node init(int val, int index,  int priority)
        {
            Node ret = new Node();            
            ret.val = val;
            ret.prior = priority;
            return ret;
        }
     

        public static void print(Node node)
        {
            traverse(node);
            Console.WriteLine();
        }

        public static void traverse(Node root)
        {
            if (root != null)
            {                
                traverse(root.l);
                Console.Write("[{0}],", root.val);
                traverse(root.r);
            }
        }
        
    }
}
