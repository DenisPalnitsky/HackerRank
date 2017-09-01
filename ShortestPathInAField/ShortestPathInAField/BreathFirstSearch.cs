using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInAField
{
    class BreathFirstSearch
    {
        Dictionary<int, HashSet<int>> adjList;

        public static int BFS(Dictionary<int, HashSet<int>> adjList, int startPoint, int endPoint)
        {
            var b = new BreathFirstSearch();
            b.adjList = adjList;
                        
     
            var discovered = new Dictionary<int, int>();

            discovered[startPoint] = 0;

            return  b.bfs(startPoint, endPoint, discovered);
        }

        private int bfs(int startPointId, int endPointId, Dictionary<int, int> discoverd)
        {
            var visited = new Queue<int>();
            visited.Enqueue(startPointId);
           
            while (visited.Count!=0)
            {
                var v = visited.Dequeue();

                foreach ( var u in adjList[v])
                {
                    if (u == endPointId)
                        return discoverd[v] + 1;

                    if (!discoverd.ContainsKey(u))
                    {
                        discoverd[u] = discoverd[v] + 1 ;
                        visited.Enqueue(u);
                    }
                }
            }

            return -1;
        }
    }
}
