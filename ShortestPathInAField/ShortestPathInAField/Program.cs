using System;
using System.Collections.Generic;

namespace ShortestPathInAField
{
    class Program
    {
        static int[,] field = new int[4, 4] {
                {0, 0, 0, 0},
                {1, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 0}};

        static void Main(string[] args)
        {
            
            var startPoint = new[] { 2, 0 };
            var endPoint = new[] { 0, 0 };

            ShortesPathLength(field, startPoint, endPoint);
        }

        private static void ShortesPathLength(int[,] field, int[] startPoint, int[] endPoint)
        {
            var adjList = ConvertToAdjencyMatrix(field);


            int c = BreathFirstSearch.BFS(adjList,
                11,
                8);

            Console.WriteLine(" Result = " + c);
            Console.ReadKey();
        }

     

        private static Dictionary<int, HashSet<int>> ConvertToAdjencyMatrix(int[,] field)
        {            
            var edges = new Dictionary<int, HashSet<int>>();
            
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j= 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        var adj = new HashSet<int>();

                        AddAdj(field, i-1 , j, adj);
                        AddAdj(field, i + 1, j, adj);
                        AddAdj(field, i , j-1, adj);
                        AddAdj(field, i , j+1, adj);
                        edges.Add(GetCoordinateId(i, j), adj);
                    }
                }
            }
                        
            return edges;
        }

        private static void AddAdj(int[,] field, int i, int j, HashSet<int> adj)
        {
            if (IsEdge(i, j , field))
                adj.Add(GetCoordinateId(i, j ));
        }

        static bool IsEdge(int x, int y, int[,] field)
        {
            if(x>= 0 && x< field.GetLength(0) && y>=0 && y< field.GetLength(1) )
            {
                return field[x, y] == 0;
            }

            return false;
        }

        public static int GetCoordinateId( int x, int y)
        {        
            return field.GetLength(1) * x  + y ;            
        }
    }
}
