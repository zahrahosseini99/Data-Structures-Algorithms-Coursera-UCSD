using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A5
{
    public class Q2MajorityElement : Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            if (IsMajor(a, FindElemnt(a)))
                return 1;
            else
                return 0;

        }
        public static long FindElemnt(long[] a)
        {
            long count = 0;
            long major = 0;

            foreach (var number in a)
            {
                if (count == 0)
                {
                    major = number;
                }
                if (number == major)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return major;
        }

        public static bool IsMajor(long[] a, long cand)
        {
            long count = 0;
            foreach (var number in a)
            {
                if (number == cand)
                {
                    count++;
                }
            }
            return (count > a.Length / 2);
        }


    }
}
