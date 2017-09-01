using System;
using System.Collections.Generic;
using System.Linq;


namespace HackerRank.BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int m = 1;
            int[,] e = new int[,] { { 2, 3 } } ;

            Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < n; i++)
            {
                adjList[i+1] = new HashSet<int>();
            }

            for (int i =0; i< m; i++)
            {
                adjList[e[i, 0]].Add(e[i, 1]);
                adjList[e[i, 1]].Add(e[i, 0]);
            }

            int s = 2;

            // solution
            var discovered = new SortedDictionary<int, int>();

            for (int i = 0; i < n; i++)
                discovered[i+1] = -1;

            discovered[s] = 0;

            bfs(adjList, s, discovered);

            Console.WriteLine(String.Join(" ", discovered.Values.Reverse().Where(i => i != 0)));
            Console.ReadKey();
        }



            private static void bfs(Dictionary<int, HashSet<int>> adjList, int startPointId, SortedDictionary<int, int> discoverd)
            {
                var visited = new Queue<int>();
                visited.Enqueue(startPointId);

                while (visited.Count != 0)
                {
                    var v = visited.Dequeue();

                    foreach (var u in adjList[v])
                    {                  
                        if (discoverd[u] < 0)
                        {
                            discoverd[u] = discoverd[v] + 6;
                            visited.Enqueue(u);
                        }
                    }
                }            
            }
    }
}
