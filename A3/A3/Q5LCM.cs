using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);
        public long GCD(long a, long b)
        {
            if (a == 0)
                return b;

            return GCD(b % a, a);
        }
        public long Solve(long a, long b)
        {
            if (a > b && a % b == 0)
            {
                return a;
            }
            else if (b > a && b % a == 0)
            {
                return b;
            }
            if (GCD(a, b) == 1)
            {
                return a * b;
            }
            else
                return a * b / GCD(a, b);
        }
    }
}
