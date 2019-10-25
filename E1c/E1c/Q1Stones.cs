using System;
using TestCommon;

namespace E1c
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

       
        public virtual long Solve(long n, long[] stones)
        {
            long sum = 0;
            int i = 0;
            while (i < stones.Length)
            {
                sum += stones[i];
                if (sum >= n)
                    break;
                i++;
            }
            if (n > sum)
                return 0;
            return i + 1;
        }
    }
}
