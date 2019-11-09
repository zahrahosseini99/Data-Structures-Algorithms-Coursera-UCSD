using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            return LCS2(seq1, seq2 );
        }
        static long LCS2(long[] seq1, long[] seq2)
        {
            long m = seq1.Length;
            long n = seq2.Length;
            int[,] Tabel = new int[m + 1, n + 1];


            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                        Tabel[i, j] = 0;
                    else if (j == 0)
                        Tabel[i, j] = 0;
                    else if (seq1[i - 1] == seq2[j - 1])
                        Tabel[i, j] = Tabel[i - 1, j - 1] + 1;
                    else
                        Tabel[i, j] = Math.Max(Tabel[i - 1, j], Tabel[i, j - 1]);
                }
            }
            return Tabel[m, n];
        }


    }
}
