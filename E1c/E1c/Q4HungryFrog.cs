using System;
using TestCommon;
using System.Linq;
namespace E1c
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);
        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[] first = new long[n];
            long[] second = new long[n];
            first[0] = numbers[0][0];
            second[0] = numbers[1][0];
            for (int i = 1; i < n; i++)
            {
                if ((first[i - 1] + numbers[0][i]) > (second[i - 1] + numbers[0][i]-p))
                    first[i] = (first[i - 1] + numbers[0][i]);
                else
                    first[i] = (second[i - 1] + numbers[0][i]-p);
                if ((second[i - 1] + numbers[1][i]) > (first[i - 1] + numbers[1][i] - p))
                    second[i] = (second[i - 1] + numbers[1][i]);
                else
                    second[i] = (first[i - 1] + numbers[1][i] - p);
            }
            if (second[n - 1] > first[n - 1])
                return second[n - 1];
            else
                return first[n - 1];
        }

       
    }
}
