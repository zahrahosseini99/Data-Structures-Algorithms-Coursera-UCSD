using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree : Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            return LCS3(seq1, seq2, seq3);
        }

        private long LCS3(long[] seq1, long[] seq2, long[] seq3)
        {
            long m = seq1.Length;
            long n = seq2.Length;
            long o = seq3.Length;
            var tabel = new long[m + 1, n + 1, o + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= o; k++)
                    {
                        if (i == 0)
                            tabel[i, j, k] = 0;
                        else if (j == 0)
                            tabel[i, j, k] = 0;
                        else if (k == 0)
                            tabel[i, j, k] = 0;
                        else if (seq1[i - 1] == seq2[j - 1] /*&& seq3[i - 1] == seq2[j - 1]*/
                            && seq1[i - 1] == seq3[k - 1]
                            )
                            tabel[i, j, k] = tabel[i - 1, j - 1, k - 1] + 1;
                        else
                            tabel[i, j, k] = Math.Max(tabel[i, j, k - 1], Math.Max(tabel[i - 1, j, k], tabel[i, j - 1, k]));
                    }
                }
            }
            return tabel[m, n, o];

        }

    }
}
