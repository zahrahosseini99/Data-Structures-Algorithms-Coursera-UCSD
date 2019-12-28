using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{

    public class Q3IsItBSTHard : Processor
    {


        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        Node[] data;
        public bool Solve(long[][] nodes)
        {
            data = new Node[nodes.Length];

            for (long i = 0; i < nodes.Length; i++)
                data[i] = new Node(nodes[i][0], nodes[i][1], nodes[i][2], -1);

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i][1] != -1)
                    data[nodes[i][1]].parent = i;

                if (nodes[i][2] != -1)
                    data[nodes[i][2]].parent = i;

            }

            long m = LeftDescendant(0);
            (long, bool) next = Next(m);
            long j = 2;
            while (j < data.Length)
            {
                if (data[next.Item1].Data < data[m].Data && next.Item2)
                    return false;
                if (data[next.Item1].Data <= data[m].Data && !next.Item2)
                    return false;
                m = next.Item1;
                next = Next(m);
                j++;
            }
            return true;
        }
        public (long, bool) Next(long n)
        {

            if (data[n].right != -1)
                return (LeftDescendant(data[n].right), true);
            else
                return (RightAncestor(n), false);
        }

        public long LeftDescendant(long n)
        {
            if (data[n].left == -1)
                return n;
            else
                return LeftDescendant(data[n].left);
        }

        public long RightAncestor(long n)
        {
            if (data[n].Data <= data[data[n].parent].Data)
                return data[n].parent;
            else
                return RightAncestor(data[n].parent);
        }
        public class Node
        {
            public long Data;
            public long left, right;
            public long parent;
            public Node(long item, long l, long r, long p)
            {
                Data = item;
                left = l;
                right = r;
                parent = p;
            }
        }
    }
}
