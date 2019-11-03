using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[]>)Solve);


        public virtual long[] Solve(long[] a, long[] b)
        {
            List<long> index = new List<long>();
            for (int i = 0; i < b.Length; i++)
            {
                index.Add(Divid(a, a.Length - 1, 0, b[i]));
            }
            return index.ToArray();


        }
        public long Divid(long[] a, long high, long low, long b)
        {

            if (b > a[high] || b < a[0])
                return -1;
            long mid = low + ((high - low) / 2);
            if (a[mid] == b)
                return mid;
            else if (b < a[mid])
                return Divid(a, mid - 1, low, b);
            else if (b > a[mid])
                return Divid(a, high, mid + 1, b);
            else
                return -1;
        }
    }
}
