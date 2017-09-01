using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInAField
{
    class Program
    {
        static int[,] field = new int[4, 4] {
                {0, 1, 0, 0},
                {1, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}};

        static void Main(string[] args)
        {
            


            var startPoint = new[] { 0, 0 };
            var endPoint = new[] { 0, 0 };

            ShortesPathLength(field, startPoint, endPoint);
        }

        private static void ShortesPathLength(int[,] field, int[] startPoint, int[] endPoint)
        {
            var adjList = ConvertToAdjencyMatrix(field);

            Console.WriteLine($"Shortest path: {BFS(adjList, startPoint, endPoint)}"); 
          
            Console.WriteLine(adjList.Count);
        }

        private static int BFS(Dictionary<int, HashSet<int>> adjList, int[] startPoint, int[] endPoint)
        {
            Queue<int> visited = new Queue<int>();
            int count = 0;

            return bfsRecursive(adjList, 
                GetCoordinateId(startPoint[0], startPoint[1]),
                GetCoordinateId(endPoint[0], endPoint[1]) , visited, count);
            
        }

        private static int bfsRecursive(Dictionary<int, HashSet<int>> adjList, int startPointId, int endPointId, Queue<int> visited, int count)
        {
            if (visited.Contains(startPointId))
            {
                return count;
            }

            count++;
            visited.Enqueue(startPointId);


            foreach (var v in adjList[startPointId])
            {
                bfsRecursive(adjList, v, endPointId, visited, count);
            }

            return count;
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

                        if (IsEdge(i - 1, j - 1, field))
                            adj.Add(GetCoordinateId(i, j - 1));

                        if (IsEdge(i - 1, j, field))
                            adj.Add(GetCoordinateId(i - 1, j));

                        if (IsEdge(i + 1, j + 1, field))
                            adj.Add(GetCoordinateId(i + 1, j));

                        if (IsEdge(i + 1, j + 1, field))
                            adj.Add(GetCoordinateId(i, j + 1));

                        edges.Add(GetCoordinateId(i, j), adj);
                    }
                }
            }
                        
            return edges;
        }
        
        static bool IsEdge(int x, int y, int[,] field)
        {
            if(x>= 0 && x< field.GetLength(0) && y>=0 && y< field.GetLength(1) )
            {
                return field[x, y] == 0;
            }

            return false;
        }

        static int GetCoordinateId( int x, int y)
        {
            if (y <= 0)
                return x;

            return field.GetLength(0)* y  + x ;
            
        }
    }
}
