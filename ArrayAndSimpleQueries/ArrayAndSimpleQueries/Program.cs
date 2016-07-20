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
            var root = Treap.init(50,15);                                    
            var node2 = Treap.init(30, 5);            
            var node3 = Treap.init(70, 10);
            var node4 = Treap.init(20, 2);
            var node5 = Treap.init(40, 4);                    

            Treap.insert(ref root, node2);
            Treap.insert(ref root, node3);
            Treap.insert(ref root, node4);
            Treap.insert(ref root, node5);
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
