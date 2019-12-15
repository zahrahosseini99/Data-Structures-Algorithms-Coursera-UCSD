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
            //List<long> occurrences = new List<long>();
            //int startIdx = 0;
            //int foundIdx = 0;
            //while ((foundIdx = text.IndexOf(pattern, startIdx)) >= startIdx)
            //{
            //    startIdx = foundIdx + 1;
            //    occurrences.Add(foundIdx);
            //}
            //return occurrences.ToArray();
            return RabinKrap(text, pattern).ToArray();
        }

        public static long Polyhash(string s, long p, long x)
        {
            //checked
            //{
            //    long hash = 0;
            //    foreach (var c in s)
            //        hash = ((hash * x + (int)c) % p +  p) % p;
            //    return hash;
            //}
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
            //injaaaa
            string str = T.Substring(T.Length - Patternlen);
            H[T.Length - Patternlen] = Polyhash(str, p, x);

            long y = 1;
            //injaaaa
            for (int i = 1; i <= Patternlen; i++)
            {
                y = ((y * x) % p + p) %p;
            }
            //injaaa
            for (int i = T.Length - Patternlen - 1; i >= 0; i--)
            {
                H[i] = ((x * H[i + 1] + T[i] -  y * T[i + Patternlen]) %p +p) % p;
            }
            return H;
        }

        public static List<long> RabinKrap(string T, string P)
        {
            // long[] hashes = new long[T.Length - P.Length + 1];
            int bigPrim = 1000000007;
            Random rand = new Random();
            //long x = rand.Next(0, bigPrim); 
            long x = 236;
            var hashes = PreComputeHashes(T, P.Length, bigPrim, x);
            var positions = new List<long>();
            long pHash = Polyhash(P, bigPrim, x);

            //injaaaaaa
            for (int i = 0; i <= T.Length - P.Length; i++)
            {
                if (pHash != hashes[i])
                    continue;
                //injaaaaaaaaaaaa
                if (T.Substring(i, P.Length) == P)
                    positions.Add(i);
            }
            return positions;
        }

        //private static bool AreEqual(string a, string b)
        //{
        //    if (a.Length != b.Length)
        //        return false;
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (a[i] != b[i])
        //            return false;
        //    }
        //    return true;
        //}
    }
}
