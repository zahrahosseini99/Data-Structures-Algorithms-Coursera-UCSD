using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);


        public virtual long Solve(long money)
        {
            long count = 0;
            long mon = 0;
            count += (money / 10);
            mon = money % 10;
            count += (mon / 5);
            mon = money % 5;
            count += (mon / 1);
            return count;
        }
    }
}
