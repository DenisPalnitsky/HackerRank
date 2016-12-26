using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    class Query
    {
        public int QueryType;
        public int i;
        public int j;

        public Query(int t, int i, int j)
        {
            QueryType = t;
            this.i = i-1;
            this.j = j-1;
        }
    }

    class Program
    {                

        static void Main(string[] args)
        {


            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
                                                 
            var root = Extension.FromArray(arr);
            
            Treap.print(root);
          

            //1 2 4
            //2 3 5
            //1 4 7
            //2 1 4

            performQuery(ref root, new Query(1, 2, 4));
            Treap.print(root);
            
            performQuery(ref root, new Query(2, 3, 5));
            Treap.print(root);
            
            performQuery(ref root, new Query(1, 4, 7));
            Treap.print(root);

            performQuery(ref root, new Query(2, 1, 4));
            Treap.print(root);

            
            Treap.print(root);

            Console.ReadKey();
        }

      
      
        private static void Solution()
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

        public static void performQuery(ref Node root, Query q)
        {
            switch (q.QueryType)
            {
                case 1:
                    root = PerforQ1(root, q);
                    break;
                case 2:
                    root = PerforQ2(root, q);
                    break;
            }
        }

        private static Node PerforQ1(Node root, Query q)
        {
            Node l = null;
            Node middle = null;
            Node r = null;

            Treap.split(q.i, root, out l, out r);
            Treap.split(q.j, r, out middle, out r);

            Treap.merge(ref middle, middle, l);
            Treap.merge(ref middle, middle, r);
            root = middle;
            root.recalc();
            return root;
        }

        private static Node PerforQ2(Node root, Query q)
        {
            Node l = null;
            Node middle = null;
            Node r = null;

            Treap.split(q.i, root, out l, out r);
            
            Treap.split(q.j, r, out middle, out r);

            Treap.merge(ref l, l,  r );            
            Treap.merge(ref l, l, middle);
            root = l;
            root.recalc();
            return root;
        }
        
    }
}
