using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);
        public class Node
        {
            public long data;
            public Node left, right;
            public long index;
            public Node(long item, long i)
            {
                data = item;
                left = right = null;
                index = i;
            }
        }
        public bool Solve(long[][] nodes)
        {
            Node[] data = new Node[nodes.Length];
            data = Initialization(nodes);

            return IsItBst(data);
        }
        private Node[] Initialization(long[][] nodes)
        {
            Node[] data = new Node[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                Node a = new Node(nodes[i][0], i);
                if (nodes[i][2] != -1)
                {
                    a.right = new Node(nodes[nodes[i][2]][0], nodes[i][2]);
                }
                else
                    a.right = null;
                if (nodes[i][1] != -1)
                {
                    a.left = new Node(nodes[nodes[i][1]][0], nodes[i][1]);
                }
                else
                    a.left = null;
                a.index = i;
                data[i] = a;
            }
            return data;
        }

        public bool IsItBst(Node[] nodes)
        {
            long[] bst = Inorder(nodes);
            return arraySortedOrNot(bst, bst.Length);

        }
        static bool arraySortedOrNot(long[] arr, int n)
        {
            if (n == 0 || n == 1)
                return true;

            for (int i = 1; i < n; i++)

                if (arr[i - 1] > arr[i])
                    return false;
            return true;
        }
        public long[] Inorder(Node[] nodes)
        {
            long i = 0;
            long index = 0;
            Stack<Node> Inorder = new Stack<Node>();
            Node start = nodes[0];
            long[] res = new long[nodes.Length];
            while (start != null || Inorder.Count > 0)
            {
                while (start != null)
                {
                    index = start.index;
                    Inorder.Push(start);
                    start = nodes[index].left;
                }
                start = Inorder.Pop();
                index = start.index;
                res[i++] = start.data;
                start = nodes[index].right;
            }

            return res;
        }
        //public Node Next(Node n)
        //{
        //    if (n.right != null)
        //        return LeftDescendant(n.right);
        //    else

        //        return RightAncestor(n);
        //}

        //private Node RightAncestor(Node n)
        //{
        //    if (n.data < n.)
        //}

        //private Node LeftDescendant(Node n)
        //{
        //    if (n.left == null)
        //        return n;
        //    else
        //        return LeftDescendant(n.left);

        //}
    }
}
