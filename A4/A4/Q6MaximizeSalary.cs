using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>)Solve);

        public long Maximum(long[] numbers)
        {
            long max = numbers[0];
            foreach (var c in numbers)
            {
                max = Check(max, c);
            }
            return max;
        }

        private long Check(long max, long c)
        {
            string a = max.ToString() + c.ToString();
            string b = c.ToString() + max.ToString();
            if (long.Parse(a) > long.Parse(b))
                return max;
            else
                return c;
        }
        public virtual string Solve(long n, long[] numbers)
        {
            string finalnumber = string.Empty;
            var nums = numbers.ToList();
            int i = 0;
            long max = 0;
            while (nums.Count > 0)
            {
                i++;
                max = Maximum(nums.ToArray());
                finalnumber += max.ToString();
                nums.Remove(max);
            }
            return finalnumber;
        }

    }
}

