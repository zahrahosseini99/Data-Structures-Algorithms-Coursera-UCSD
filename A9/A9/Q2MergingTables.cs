using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Tables
    {
        public long[] rank;
        public long[] parent;

        public long[] tsize;
        int n;
        public Tables(long[] t, long[] p,long n)
        {
            rank = new long[n];
            parent = p;
            tsize = t;
        }


        public long find(long x)
        {

            if (parent[x] != x)
            {
                parent[x] = find(parent[x]);
            }
            return parent[x];
        }
       
        public long Union(long dest, long source)
        {
            long res = tsize.Max();
            long realdest = find(dest);
            long realsource = find(source);
            if (realdest == realsource)
            {
                if (res == 0)
                    return tsize.Max();
                return res;
            }

            if (rank[realsource] > rank[realdest])
            {

                parent[realsource] = realdest;
                tsize[realdest] = tsize[realsource] + tsize[realdest];
                tsize[realsource] = 0;
                res = Math.Max(res, tsize[realdest]) ;
            }
            else
            {
                parent[realdest] = realsource;
                tsize[realsource] = tsize[realsource] + tsize[realdest];
                tsize[realdest] = 0;
                res = Math.Max(res, tsize[realsource]);
                if (rank[realdest] == rank[realsource])
                    rank[realsource] += 1;
            }
            return res;
        }

    }
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            long m = targetTables.Length;
            long[] parent = new long[tableSizes.Length + 1];
           
            for (int i = 0; i <= tableSizes.Length; i++)
            {

                parent[i] = i;
            }
            
            Tables example = new Tables(tableSizes, parent, tableSizes.Length);

            long[] res = new long[m];
            for (int i = 0; i < m; i++)
            {
               long a = example.Union(targetTables[i] - 1, sourceTables[i] - 1);
                if (i != 0)
                {
                    res[i] = Math.Max(res[i - 1], a);
                }
                else
                    res[i] = a;
            }

            return res;
        }

    }
}
