using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public class Node
        {
            public long data;
            public Node right, left;
            public long index;
            public Node(long _data, long _index)
            {
                data = _data;
                right = left = null;
                index = _index;
            }
        }
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] BST)
        {
          
            Node[] nodes = new Node[BST.Length];
            for (int i = 0; i < BST.Length; i++)
            {
              
                Node a ;

                if (BST[i] != -1)
                {
                    a = new Node(BST[i], i);


                    if (BST[LeftChild(i)] != -1)
                        a.left = new Node(BST[LeftChild(i)], LeftChild(i));
                    else
                        a.left = null;
                    if (BST[RightChild(i)] != -1)
                        a.right = new Node(BST[RightChild(i)], RightChild(i));
                    else
                        a.left = null;
                    nodes[i] = a;
                }
                else
                    nodes[i] = null;
            }
            
          
                var res=Inorder(nodes);
           
            var j = 0;
            List<long> b = new List<long>();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i]!= 0)
                  b.Add( res[i]);
            }
            return b.ToArray();
        }
        public long Parent(long index) => index/2;
        public long LeftChild(long index) => 2 * index + 1;
        public long RightChild(long index) => 2 * index + 2;
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
    }
}