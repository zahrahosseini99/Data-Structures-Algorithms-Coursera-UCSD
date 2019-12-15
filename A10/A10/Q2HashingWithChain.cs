using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        protected static List<string>[] hashing;

        public string[] Solve(long bucketCount, string[] commands)
        {
            hashing = new List<string>[bucketCount];
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {

            long hash = 0;
            checked
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    
                    hash = (hash * x + (int)str[i]) % p;
                }
            }

            return (hash % hashing.Length);
        }

        public void Add(string str)
        {
            long key = PolyHash(str, 0, str.Length, BigPrimeNumber, 263);
            if (hashing[key] != null)
            {
                for (int i = 0; i < hashing[key].Count; i++)
                {
                    if (hashing[key][i] == str)
                    {
                        return;
                    }

                }
                hashing[key].Add(str);
            }
            else
            {
                hashing[key] = new List<string>();
                hashing[key].Add(str);
            }
        }

        public string Find(string str)
        {
            string res = "no";
            long key = PolyHash(str, 0, str.Length, BigPrimeNumber, 263);
            if (hashing[key] == null)
                return res;
            for (int i = 0; i < hashing[key].Count; i++)
            {
                if (str == hashing[key][i])
                    res = "yes";
            }
            return res;
        }

        public void Delete(string str)
        {
            long key = PolyHash(str, 0, str.Length, BigPrimeNumber, 263);
            if (hashing[key] == null)
                return;
            for (int i = 0; i < hashing[key].Count; i++)
            {
                if (str == hashing[key][i])
                {
                    hashing[key].RemoveAt(i);
                    return;
                }
            }
        }

        public string Check(int i)
        {
            string res = string.Empty;
            if (hashing[i] == null)
                return "-";
            else if (hashing[i].Count != 0)
            {
                for (int j = hashing[i].Count - 1; j >= 0; j--)
                {
                    res += hashing[i][j] + " ";
                }
            }
            else
            {
                return "-";
            }

            return res.TrimEnd();
        }
    }
}
