using System;
using System.Collections.Generic;
using TestCommon;
using System.Linq;
namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            //long sum = 0;
            //List<Tuple<long, int>> nums = new List<Tuple<long, int>>();
            //for (int i = 0; i < n; i++)
            //{
            //    nums.Add(Tuple.Create(numbers[i],i));
            //}
          long m=  numbers.ToList().Max();
            for (int i = 0; i < n; i++)
            {
                if (m == numbers[i])
                    m += numbers[i + 1];
            }
            return m;
        }
        //public long Maximum(long[] numbers)
        //{
        //    long max = numbers[0];
        //    foreach (var c in numbers)
        //    {
        //        if (max + c > max)
        //            max = max + c;
        //    }
        //    return max;
        //}

        //private long Check(long max, long c)
        //{
        //    if (max + c > max)
        //        max = max + c;
        //    return max;
        //}
    }
}
