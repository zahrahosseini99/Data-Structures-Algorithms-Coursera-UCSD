using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class Node
    {
        public long data;
        public Node  left, right;
        public long index;
       public  long parent;
        public Node(long item, long i)
        {
            data = item;
           left = right = null;
            index = i;
           
        }
    }

    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            long[][] b = new long[3][];
            Node[] data = new Node[nodes.Length];
            data = Initialization(nodes);
            b[0] = Inorder(data);
            b[1] = PreOrder(data);
            b[2] = PostOrder(data);
            return b;
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

        public long[] PreOrder(Node[] nodes)
        {
            long index = 0;
            Stack<Node> preOrder = new Stack<Node>();
            preOrder.Push(nodes[0]);
            long[] res = new long[nodes.Length];
            int i = 0;
            while (preOrder.Count > 0)
            {
                Node n = preOrder.Peek();
                index = n.index;
                res[i++] = preOrder.Pop().data;

                if (nodes[index].right != null)
                {
                    preOrder.Push(nodes[index].right);
                }
                if (nodes[index].left != null)
                {
                    preOrder.Push(nodes[index].left);
                }

            }
            return res;
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
        public long[] PostOrder(Node[] nodes)
        {
            Stack<Node> first = new Stack<Node>();
            Stack<Node> second = new Stack<Node>();
            first.Push(nodes[0]);
            long index = 0;
            int i = 0;
            long[] res = new long[nodes.Length];
            while (first.Count > 0)
            {
                Node n = (Node)first.Pop();
                index = n.index;
                second.Push(n);

                if (nodes[index].left != null)
                {
                    first.Push(nodes[index].left);
                }
                if (nodes[index].right != null)
                {
                    first.Push(nodes[index].right);
                }

            }
            while (second.Count > 0)
            {
                Node m = (Node)second.Pop();
                res[i++] = m.data;
            }
            return res;
        }


    }
}