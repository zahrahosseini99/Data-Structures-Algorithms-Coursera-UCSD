using System;
using TestCommon;

namespace E1c
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {

            long max = int.MinValue;
            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum = sum + numbers[i];

                if (max < sum)
                    max = sum;

                if (sum < 0)
                    sum = 0;
            }

            return max;
        }
    }
}
