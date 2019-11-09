using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            return sequence(n);
        }

        public long[] sequence(long n)
        {
            long[] table = new long[n + 1];
            table[0] = 0;
            table[1] = 1;

            for (long i = 2; i < n + 1; i++)
            {
                table[i] = int.MaxValue;
                long count3 = int.MaxValue;
                long count2 = int.MaxValue;
                long count1 = int.MaxValue;
                if (i % 3 == 0)
                    count3 = table[i / 3] + 1;
                if (i % 2 == 0)
                    count2 = table[i / 2] + 1;

                count1 = table[i - 1] + 1;
                table[i] = Math.Min(count3, Math.Min(count1, count2));
            }

            var nums = new List<long>();
            while (n >= 1)
            {
                nums.Add(n);
                if (n % 3 == 0 && table[n / 3] + 1 == table[n])
                {
                    n = n / 3;
                }
                else if (n % 2 == 0 && table[n / 2] + 1 == table[n])
                {
                    n = n / 2;
                }
                else if (table[n - 1] + 1 == table[n])
                {

                    n = n - 1;

                }


            }
            return nums.OrderBy(x => x).ToArray();


        }
    }
}
