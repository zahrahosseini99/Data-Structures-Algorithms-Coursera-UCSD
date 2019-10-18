using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)Solve);
        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<Tuple<long, long>> numbers = new List<Tuple<long, long>>();
            for (int i = 0; i < startTimes.Length; i++)
            {
                numbers.Add(Tuple.Create(startTimes[i], endTimes[i]));
            }
            numbers = numbers.OrderBy(t => t.Item1).ToList();
            return Check(numbers);
        }
        public long Check(List<Tuple<long, long>> nums)
        {
            List<long> points = new List<long>();
            long min = nums.Min(t => t.Item2);
            points.Add(min);
            int i = 0;
            while (nums.Count > i)
            {
                if (nums[i].Item1 <= min)
                    nums.Remove(nums[i]);
                else
                {
                    min = nums.Min(t => t.Item2);
                    points.Add(min);
                    if (nums[i].Item1 < min)
                        nums.Remove(nums[i]);
                }
            }
            return points.Count;
        }


    }

}
