using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    class Program
    {
              [DebuggerDisplay("Val={val}, Prior={prior}")]
        class Node
        {
            public int val;
            public int prior;

            public Node l;
            public Node r;
        }

        static Random randomizer = new Random();

        static void split(Node t, ref Node l, ref Node r, int key)
        {
            if (t == null)
            {
                l = null;
                r = null;
            }
            else if (t.val <= key)
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

        void merge(ref Node t, Node l, Node r)
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

        static void insert(ref Node t, Node it)
        {
            if (t == null)
                t = it;
            else if (it.prior > t.prior)
            {
                split(t, ref it.l, ref it.r, it.val);
                t = it;
            }
            else
            {
                var node = t.val <= it.val ? t.r : t.l;
                insert(ref node, it);
            }
        }

        static Node init(int val)
        {
            Node ret = new Node();
            ret.val = val;
            ret.prior = randomizer.Next();
            return ret;
        }

        static void AddL(ref Node l)
        {
            l = new Node() { val = 5 };
        }

        static void Main(string[] args)
        {            
            var root = init(10);
            var node5 = init(5);
            var node20 = init(20);

            insert(ref root, node5);
            print(root);

            insert(ref root, node20);
            print(root);

            Console.ReadKey();
        }

        static void print (Node node)
        {
            traverse(node);
            Console.WriteLine();
        }

        static void traverse(Node root)
        {
            if (root != null)
            {
                Console.Write("[{0}:{1}],", root.val, root.prior);
                traverse(root.l);
                traverse(root.r);
            }
        }
        
        

        class Query
        {
            public int QueryType;
            public int I;
            public int J;

            public Query(int t, int i, int j)
            {
                QueryType = t;
                I = i;
                J = j;
            }
        }

        static void Main(string[] args)
        {
            var line1 = readIntArrayFormInput();

            var array = readIntArrayFormInput();
            
            for (int i = 0; i < line1[1]; i++)
            {
                var queryInts = readIntArrayFormInput();
                var query = new Query(queryInts[0], queryInts[1], queryInts[2]);
            }
        }

        private static int[] readIntArrayFormInput()
        {
            return Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        private static void PerforQuery( int[] array, Query query )
        {

            switch (query.QueryType)
            {
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        
    }
}
