using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize,
            long[] arrivalTimes,
            long[] processingTimes)
        {

            return Network(arrivalTimes, processingTimes, bufferSize);
        }

        private long[] Network(long[] arrivalTimes, long[] processingTimes, long bufferSize)
        {
Queue<long> numbers = new Queue<long>();
            long[] res = new long[arrivalTimes.Length];
            long startTime = 0;
            if (arrivalTimes.Length == 1)
            {
res[0] = (arrivalTimes[0]);
                return res;
            }
            if (arrivalTimes.Length == 0)
            {
                return res;
            }
            if (arrivalTimes.Length != 0)
            {
                startTime = arrivalTimes[0];

                numbers.Enqueue(0);
            }
            for (int i = 1; i < arrivalTimes.Length; i++)
            {
                while (numbers.Count != 0 &&
                    startTime + processingTimes[numbers.Peek()] <= arrivalTimes[i])
                {
                    long index = numbers.Peek();
                    if (startTime <= arrivalTimes[index])
                        startTime = arrivalTimes[index];
                    res[index] = (startTime);
                    startTime += processingTimes[index];
                    numbers.Dequeue();
                }
                if (bufferSize >= numbers.Count + 1)
                {
                    numbers.Enqueue(i);
                }
                else
                {
                    res[i] = -1;
                }
            }
            while (numbers.Count != 0)
            {

                long index = numbers.Peek();
                if (startTime <= arrivalTimes[index])
                    startTime = arrivalTimes[index];
                res[index] = (startTime);
                startTime += processingTimes[numbers.Peek()];
                numbers.Dequeue();

            }

            return res;

        }
    }


}
