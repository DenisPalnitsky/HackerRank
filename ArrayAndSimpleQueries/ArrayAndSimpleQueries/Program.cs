using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndSimpleQueries
{
    class Program
    {        
        class Query
        {
            public int QueryType;
            public int i;
            public int j;

            public Query(int t, int i, int j)
            {
                QueryType = t;
                i = i;
                j = j;
            }
        }


        // TODO: Fix doesn't work
        public static void testSplit()
        {
            int[] arr = { 1, 2, 3, 4, 5};

            //int[] arr = new int[100];
            //for (int i = 0; i < 100; i++)
            //    arr[i] = i;                            
                        

            var root = parse(arr);

            Treap.print(root);
            Node l = null, r = null;
            Treap.split(3, root, out l, out r);

            Treap.merge(ref root, r, l);
            
            
            Treap.print(root);

        }

        static void Main(string[] args)
        {

            testSplit();

            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            //int[] arr = new int[100];
            //for (int i = 0; i < 100; i++)
            //    arr[i] = i;                            
                        

            var root = parse(arr);
            
            Treap.print(root);
          

            //1 2 4
            //2 3 5
            //1 4 7
            //2 1 4

            performQuery(ref root, new Query(1, 2, 4));
            //performQuery(root, new Query(2, 3, 5));
            //performQuery(root, new Query(1, 4, 7));
            //performQuery(root, new Query(2, 1, 4));

            
            Treap.print(root);

            Console.ReadKey();
        }

        private static Node parse(int[] array)
        {

            var root = Treap.init(array[0]);

            for (int i=1; i< array.Length;i++)
            {                
                Treap.add(ref root, Treap.init(array[i]));
            }

            return root;
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

        private static void performQuery(ref Node root, Query q)
        {
            switch (q.QueryType)
            {
                case 1:
                    Node l = null;
                    Node middle = null; 
                    Node r = null;
                    
                    Treap.split(q.i, root, out l, out r);
                    Treap.split(q.j, r, out middle, out r);

                    Treap.merge(ref middle, middle, l);
                    Treap.merge(ref middle, middle, r);
                    root = middle;
                    break;
                case 2:
                    break;
            }
        }
        
    }
}
