using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {

           long sum = 0;
            long n = goldBars.Length;
            long[,] weight = new long[n + 1, W + 1];
            for (long i = 0; i <= n; i++)
            {
                for (long j = 0; j <= W; j++)
                    if (i == 0 || j == 0)
                        weight[i, j] = 0;
                    else
                    {
                        weight[i, j] = weight[i - 1, j];
                        if (j >= goldBars[i - 1])
                        {
                            sum = weight[i - 1,j - goldBars[i - 1]] + goldBars[i - 1];
                            if (sum > weight[i, j])
                                weight[i, j] = sum;
                        }

                    }
              

            }
            return weight[n, W];
        }
    }
}
