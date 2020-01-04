using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);
        public bool[] visited;
        public long[] CCnum;
        public long cc;
        public long Solve(long nodeCount, long[][] edges)
        {
            visited = new bool[nodeCount];
            CCnum = new long[nodeCount];
            List<long>[] g = graph(nodeCount, edges);
            for (int i = 0; i < nodeCount; i++)
                visited[i] = false;
            DFS(g);
            return cc;
        }
        public void Explore(long v, List<long>[] g)
        {
            Stack<long> explore = new Stack<long>();
            explore.Push(v);
            long explored = 0;
            while (explore.Any())
            {
                explored = explore.Pop();
                visited[explored - 1] = true;
                CCnum[explored - 1] = cc;
                foreach (var w in g[explored - 1])
                    if (!visited[w - 1])
                        explore.Push(w);
            }

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
        public void DFS(List<long>[] g)
        {
            cc = 0;
            for (int i = 0; i < g.Length; i++)
            {
                if (!visited[i])
                {
                    Explore(i + 1, g);
                    cc++;
                }

            }
        }
    }
}
