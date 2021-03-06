using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {

            var a = adRevenue.ToList();
            a.Sort();
            var l = averageDailyClick.ToList();
            l.Sort();

            long sum = 0;
            for (int i = 0; i < adRevenue.Length; i++)
            {
                sum += (a[i] * l[i]);
            }
            return sum;
        }

    }
}
