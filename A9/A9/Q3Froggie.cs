using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            //throw new NotImplementedException();
            SimplePriorityQueue<long, long> jumps = new SimplePriorityQueue<long, long>();
            long energy = initialEnergy;
            long prev = 0;
            long counter = 0;
            while (energy<initialDistance)
            {
                for (int i = 0; i < distance.Length; i++)
                {
                    if ((initialDistance-distance[i])<=energy && (initialDistance-distance[i])>prev)
                    {
                        jumps.Enqueue(-1 * food[i], -1 * food[i]);
                    }
                }
                if (jumps.Any())
                {
                    prev = energy;
                    energy += -1 * jumps.Dequeue();
                    counter++;
                }
                else
                {
                    return -1;
                }
            }
            return counter;
        }
    }
}
