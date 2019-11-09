using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            return EditDistance(str1, str2);
        }

        static long EditDistance(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;
            long[,] tabel = new long[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                        tabel[i, j] = j;
                    else if (j == 0)
                        tabel[i, j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        tabel[i, j] = tabel[i - 1, j - 1];
                    else
                        tabel[i, j] = 1 + Math.Min(tabel[i, j - 1],
                                    Math.Min(tabel[i - 1, j], tabel[i - 1, j - 1]));
                }
            }
            return tabel[m, n];
        }
    }
}
