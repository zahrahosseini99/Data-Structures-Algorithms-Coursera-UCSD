using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public List<long> GetMod(long n)
        {
            List<long> mods = new List<long>();
            mods.Add(0);
            mods.Add(1);
            for (int i = 2; ; i++)
            {
                mods.Add((mods[i - 1] + mods[i - 2]) % 10);
                if (mods[i] == 1 && mods[i - 1] == 0)
                    return mods;
            }
        }
        public long Solve(long n)
        {
            List<long> mods = GetMod(n);
            long pro = mods[(int)(n % 60)] * (mods[(int)(((n - 1) % 60))] + mods[(int)(n % 60)]);
            return pro % 10;
        }

    }
}
