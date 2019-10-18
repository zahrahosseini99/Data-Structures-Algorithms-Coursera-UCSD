using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)Solve);
        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            List<Tuple<long, long, float>> numbers = new List<Tuple<long, long, float>>();
            for (int i = 0; i < weights.Length; i++)
            {
                float d = (float)values[i] / (float)weights[i];
                numbers.Add(Tuple.Create(weights[i], values[i], d));
            }
            numbers = numbers.OrderByDescending(t => t.Item3).ToList();
            int j = 0;
            long value = 0;
            while (capacity > numbers[j].Item1)
            {
                capacity = capacity - numbers[j].Item1;
                value = value + numbers[j].Item2;
                j++;
            }
            value = value + (long)(numbers[j].Item3 * capacity);
            return value;
        }



        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
