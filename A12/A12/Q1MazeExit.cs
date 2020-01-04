using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            var a = Maze(StartNode, graph(nodeCount, edges), nodeCount);
            if (a.Contains(EndNode))
                return 1;
            else
                return 0;
        }
        public List<long>[] graph(long count, long[][] nodes)
        {
            List<long>[] graph = new List<long>[count];
            for (int i = 0; i < count; i++)
            {
                graph[i] = new List<long>();
            }
            foreach (var g in nodes)
            {
                graph[g[0] - 1].Add(g[1]);
                graph[g[1] - 1].Add(g[0]);
            }
            return graph;
        }
        public List<long> Maze(long start, List<long>[] graph, long count)
        {
            Queue<long> bfs = new Queue<long>();
            List<long> g = new List<long>();
            bool[] visited = new bool[count];
            bfs.Enqueue(start);

            while (bfs.Count != 0)
            {
                long index = bfs.Peek();
                g.Add(bfs.Dequeue());
                visited[index - 1] = true;
                foreach (var a in graph[index - 1])
                {
                    if (!visited[a - 1])
                        bfs.Enqueue(a);
                }
            }
            return g;
        }

    }
}
