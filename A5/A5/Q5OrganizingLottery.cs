using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery : Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {

            List<Tuple<long, long, int>> numbers = new List<Tuple<long, long, int>>();

            for (int i = 0; i < startSegments.Length; i++)
            {
                numbers.Add(Tuple.Create(startSegments[i], (long)-1, i));
            }
            for (int i = 0; i < points.Length; i++)
            {
                numbers.Add(Tuple.Create(points[i], (long)0, i));
            }
            for (int i = 0; i < endSegment.Length; i++)
            {
                numbers.Add(Tuple.Create(endSegment[i], (long)1, i));
            }

            numbers = numbers.OrderBy(t => t.Item1).ToList();
            return Find(numbers, points);

        }

        public long[] Find(List<Tuple<long, long, int>> numbers, long[] points)
        {
            long[] nums = new long[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                nums[i] = 0;
            }
            long count = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].Item2 == -1)
                    count++;
                if (numbers[i].Item2 == 1)
                    count--;
                else if (numbers[i].Item2 == 0)
                {
                    if (nums[numbers[i].Item3] == 0)
                        nums[numbers[i].Item3] += count;
                }
            }
            return nums;

        }
    }
}
