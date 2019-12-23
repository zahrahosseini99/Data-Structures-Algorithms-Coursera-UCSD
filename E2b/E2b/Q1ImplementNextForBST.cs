using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
            //this.ExcludeTestCaseRangeInclusive(1, 10);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }
      
      
        public long Solve(long n, long node, long[] BST)
        {
          return Next(node, BST);
        }
        public long Next(long node, long[] BST)
        {
            if (BST[2*node+2] != -1)
                return LeftDescendant(2 * node + 2,BST);
            else
                return RightAncestor(node,BST);
        }
        long pa;
        private long RightAncestor(long node, long[]BST)
        {
           
            if (node % 2 == 0)
                pa = (long)((node / 2) - 1);
            else
                pa =(long)( node / 2);
            if (pa == -1)
                return -1;
            
            else if (BST[node] < BST[pa])
                return node / 2;
            else
                return RightAncestor(pa,BST);
        }

        private long LeftDescendant(long node, long[] BST)
        {
            if (BST[2*node+1] == -1)
                return node;
            else
                return LeftDescendant(2 * node + 1, BST);

        }
    }
}