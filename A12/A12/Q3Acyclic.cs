using System;
using System.Collections.Generic;
using TestCommon;
using System.Linq;
namespace A12
{
    public class Q3Acyclic : Processor
    {
        public Q3Acyclic(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            List<long> First = new List<long>();
            List<long> Middle = new List<long>();
            List<long> Second = new List<long>();
            long res = 0;
            List<long>[] g = graph(nodeCount, edges);
            for (int i = 0; i < nodeCount; i++)
            {
                First.Add(i + 1);
            }
            long v = 0;
            while (First.Count > 0)
            {
                v = First.First();
                First.RemoveAt(0);
                if (HasCyle(g, v, First, Middle, Second))
                    res = 1;
            }
            return res;
        }

        private bool HasCyle(List<long>[] g, long v, List<long> First, List<long> Middle, List<long> Second)
        {
            Replace(v, First, Middle);
            for (int i = 0; i < g[v - 1].Count; i++)
            {
                if (Second.Contains(g[v - 1][i]))
                    continue;
                if (Middle.Contains(g[v - 1][i]))
                    return true;
                if (HasCyle(g, g[v - 1][i], First, Middle, Second))
                    return true;
            }
            Replace(v, Middle, Second);
            return false;
        }

        private void Replace(long v, List<long> source, List<long> target)
        {

            source.Remove(v);
            target.Add(v);

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

    }
}