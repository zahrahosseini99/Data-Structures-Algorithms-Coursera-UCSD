using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange : Processor
    {
        private static readonly int[] COINS = new int[] { 1, 3, 4 };

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long[] coins = { 1, 3, 4 };
            return Counter(n, coins);
        }

        private long Counter(long n, long[] coins)
        {
            long[] mincoins = new long[n+1];
            mincoins[0] = 0;

            for (int i = 0; i <= n; i++)
            {
                long count = 0;
                mincoins[i] = int.MaxValue;
                for (int j = 0; j < 3; j++)
                {
                    if (i >= coins[j])
                        count = mincoins[i - coins[j]] + 1;
                    if (count <= mincoins[i])
                        mincoins[i] = count;
                }
            }
            return mincoins[n];
        }
    }
}
