using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

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
        public long Solve(long n)
        {

            List<long> mods = GetMod(n, 10);
            long sum = 0;
            for(int i = 0; i <=n%60; i++)
            {
                sum += mods[i];
            }
           return sum  % 10;

        }

     
    }
}
