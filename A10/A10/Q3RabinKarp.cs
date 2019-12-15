using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);


        public long[] Solve(string pattern, string text)
        {
            return RabinKrap(text, pattern).ToArray();
        }

        public static long Polyhash(string s, long p, long x)
        {
            long hash = 0;
            char c;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                c = s[i];
                hash = ((hash * x + (int)c) % p + p) % p;
            }
            return hash;
        }
        public static long[] PreComputeHashes(
            string T,
            int Patternlen,
            long p,
            long x)
        {
            long[] H = new long[T.Length - Patternlen + 1];
            string str = T.Substring(T.Length - Patternlen);
            H[T.Length - Patternlen] = Polyhash(str, p, x);

            long y = 1;
            for (int i = 1; i <= Patternlen; i++)
            {
                y = ((y * x) % p + p) % p;
            }
            for (int i = T.Length - Patternlen - 1; i >= 0; i--)
            {
                H[i] = ((x * H[i + 1] + T[i] - y * T[i + Patternlen]) % p + p) % p;
            }
            return H;
        }

        public static List<long> RabinKrap(string T, string P)
        {
            int bigPrim = 1000000007;
            Random rand = new Random();
            long x = rand.Next(0, bigPrim);
            var hashes = PreComputeHashes(T, P.Length, bigPrim, x);
            var positions = new List<long>();
            long pHash = Polyhash(P, bigPrim, x);
            for (int i = 0; i <= T.Length - P.Length; i++)
            {
                if (pHash != hashes[i])
                    continue;
                if (T.Substring(i, P.Length) == P)
                    positions.Add(i);
            }
            return positions;
        }
    }
}
