using System;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long sum = 0;
            int index = -1;
            if ((numbers[0][0] >= numbers[1][0]))
            {
                sum += numbers[0][0];
                index = 0;
            }

            else
            {
                sum += numbers[1][0];
                index = 1;

            }
                
            for (int i = 1; i < n; i++)
            {
                if (numbers[0][i] >= numbers[1][i])
                {
                    
                    if (index == 1)
                    {
                        sum += (numbers[0][i] - p);
                    }
                    else
                    {
                        sum += (numbers[0][i]);
                        index = 0;
                    }

                }

                else

                {
                   
                    if (index == 0)
                    {
                        sum += (numbers[1][i]-p);
                    }
                    else
                    {
                        sum += (numbers[1][i]);
                        index = 1;
                    }
                  
                }
                   
            }
            return sum;
        }
    }
}
