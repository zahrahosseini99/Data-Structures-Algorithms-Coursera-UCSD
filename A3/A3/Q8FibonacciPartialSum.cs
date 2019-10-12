using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);
        public List<long> GetMod(long n, long mod)
        {
            List<long> mods = new List<long>();
            mods.Add(0);
            mods.Add(1);
            for (int i = 2; ; i++)
            {
                mods.Add((mods[i - 1] + mods[i - 2]) % mod);
                if (mods[i] == 1 && mods[i - 1] == 0)
                    return mods;
            }
        }
        public long Solve(long a, long b)
        {
            if (a < b)
                (a, b) = (b, a);
            int c = (int)(a % 60);
            int d = (int)(b % 60);

            List<long> mods = GetMod(a, 10);
            long sum = 0;
            if (d <= c)
            {
                for (int i = d; i <= c; i++)
                {
                    sum += mods[i];
                }
            }
            else
            {
                for (int i = d; i <= 60; i++)
                {
                    sum += mods[i];
                }
                for (int i = 0; i <= c; i++)
                {
                    sum += mods[i];
                }
            }


            return sum % 10;
        }
    }
}
