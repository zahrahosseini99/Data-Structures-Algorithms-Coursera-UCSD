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
            List<long> whiteSet = new List<long>();
            List<long> graySet = new List<long>();
            List<long> blackSet = new List<long>();
            long res = 0;
            List<long>[] g = graph(nodeCount, edges);
            for (int i = 0; i < nodeCount; i++)
            {
                whiteSet.Add(i + 1);
            }
            long v = 0;
            while (whiteSet.Count>0)
            {
                v = whiteSet.First();
                whiteSet.RemoveAt(0);
                if (HasCyle(g,v, whiteSet, graySet, blackSet))
                    res= 1;
            }
            return res;
        }

        private bool HasCyle(List<long>[] g ,long v, List<long> whiteSet, List<long> graySet, List<long> blackSet)
        {
            MoveVertex(v, whiteSet, graySet);
            for (int i = 0; i <g[v-1].Count ; i++)
            {
                if (blackSet.Contains(g[v - 1][i]))
                    continue;
                if (graySet.Contains(g[v - 1][i]))
                    return true;
                if (HasCyle(g, g[v - 1][i], whiteSet, graySet, blackSet))
                    return true;
            }
            MoveVertex(v, graySet, blackSet);
            return false;
        }

        private void MoveVertex(long v, List<long> source, List<long> target)
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