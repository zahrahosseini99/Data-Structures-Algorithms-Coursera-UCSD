using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q4OrderOfCourse: Processor
    {
        public Q4OrderOfCourse(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);
        public bool[] visited;
        public long[] res;
        public long[] Solve(long nodeCount, long[][] edges)
        {
            visited = new bool[nodeCount];
            res = new long[nodeCount];
         List<long>[] g = graph(nodeCount, edges);
            for (int i = 0; i < nodeCount; i++)
                visited[i] = false;
            topo(nodeCount,g);
            return res;
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
            }
            return graph;
        }
        public void topo(long nodeCount, List<long>[] g)
        {
            Stack<long> top = new Stack<long>();

            for (int i = 0; i < nodeCount; i++)
            {
                if (visited[i]==false)
                {
                    topplogical(i+1, visited, top,g);
                }
            }
            int j = 0;
            while (top.Count != 0)
            {
                res[j++] = top.Pop();
            }

        }
      
        private void topplogical(long v, bool[] visited, Stack<long> top, List<long>[] g)
        {
            visited[v-1] = true;
            for (int j = 0; j < g[v-1].Count; j++)
            {
                if (!visited[g[v-1][j]-1])
                    topplogical(g[v - 1][j], visited, top, g);
            }
            top.Push(v);
        }

        public override Action<string, string> Verifier { get; set; } = TopSortVerifier;

        public static void TopSortVerifier(string inFileName, string strResult)
        {
            long[] topOrder = strResult.Split(TestTools.IgnoreChars)
                .Select(x => long.Parse(x)).ToArray();

            long count;
            long[][] edges;
            TestTools.ParseGraph(File.ReadAllText(inFileName), out count, out edges);

            // Build an array for looking up the position of each node in topological order
            // for example if topological order is 2 3 4 1, topOrderPositions[2] = 0, 
            // because 2 is first in topological order.
            long[] topOrderPositions = new long[count];
            for (int i = 0; i < topOrder.Length; i++)
                topOrderPositions[topOrder[i] - 1] = i;
            // Top Order nodes is 1 based (not zero based).

            // Make sure all direct depedencies (edges) of the graph are met:
            //   For all directed edges u -> v, u appears before v in the list
            foreach (var edge in edges)
                if (topOrderPositions[edge[0] - 1] >= topOrderPositions[edge[1] - 1])
                    throw new InvalidDataException(
                        $"{Path.GetFileName(inFileName)}: " +
                        $"Edge dependency violoation: {edge[0]}->{edge[1]}");

        }
    }
}
