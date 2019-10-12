using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            List<long> mods = GetMod(a, b);
            return mods[(int)(a % (mods.Count - 2))];
        }
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
    }
}
