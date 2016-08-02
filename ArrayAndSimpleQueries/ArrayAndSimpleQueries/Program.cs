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

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

            var root = parse(array);
            
            


            //1 2 4
            //2 3 5
            //1 4 7
            //2 1 4

            perforQuery(root, new Query(1, 2, 4));
            perforQuery(root, new Query(2, 3, 5));
            perforQuery(root, new Query(1, 4, 7));
            perforQuery(root, new Query(2, 1, 4));

            
            Treap.print(root);

            Console.ReadKey();
        }

        private static Node parse(int[] array)
        {
            int initialIndex =  array.Length / 2;

            var root =  Treap.init(array[initialIndex], initialIndex);

            for (int i=0;i< array.Length;i++)
            {
                if (i!= initialIndex)
                    Treap.insert(ref root, Treap.init(array[i], i));
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

        private static void perforQuery( Node root, Query query)
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
