using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            long root = 0;
            List<long>[] arr = new List<long>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                arr[i] = new List<long>();

            }
            for (int i = 0; i < nodeCount; i++)
            {
                if (tree[i] == -1)
                {
                    root = i;

                    continue;
                }

                arr[tree[i]].Add(i);
            }

            Queue<long> a = new Queue<long>();

            a.Enqueue(root);
            long[] height = new long[nodeCount];
            height[root] = 1;
            while (a.Count != 0)
            {
                long parent = a.Dequeue();
                for (int i = 0; i < arr[parent].Count; i++)
                {
                    a.Enqueue(arr[parent][i]);
                    height[arr[parent][i]] = height[parent] + 1;

                }



            }

            return height.Max();

        }



    }
}
