using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q4ParallelProcessing : Processor
    {
        public Q4ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            priorityQueue example = new priorityQueue(threadCount);
            Tuple<long, long>[] res = new Tuple<long, long>[jobDuration.Length];
            for (long i = 0; i < jobDuration.Length; i++)
            {
                res[i] = new Tuple<long, long>(example.Threads[0].Item1, example.Threads[0].Item2);
                example.ChangePriority(0, (example.Threads[0].Item1
                    , example.Threads[0].Item2 + jobDuration[i]));

            }
            return res;
        }

        public class priorityQueue
        {

            public long MaxSize;
            public (long, long)[] Threads;
            public priorityQueue(long maxsize)
            {
                MaxSize = maxsize;
                Threads = new (long, long)[maxsize];
                for (long i = 0; i < maxsize; i++)
                {
                    Threads[i] = (i, (long)0);
                }

            }
            public long Parent(long index) => (index - 1) / 2;
            public long LeftChild(long index) => index * 2 + 1;
            public long RightChild(long index) => index * 2 + 2;
            public void SiftUp(long index)
            {
                while (index > 0 && ((Threads[index].Item2 < Threads[Parent(index)].Item2)
                    || ((Threads[index].Item2 == Threads[Parent(index)].Item2)
                    && (Threads[index].Item1 < Threads[Parent(index)].Item1))))

                {
                    Swap(index, Parent(index));
                    index = Parent(index);
                }

            }
            public void SiftDown(long index)
            {
                long max = index;
                long l = LeftChild(index);
                if (
                    (l < MaxSize)
                    &&
                    (
                    (Threads[l].Item2 < Threads[max].Item2)
                    ||
                    (
                    (Threads[l].Item2 == Threads[max].Item2)
                    && (Threads[l].Item1 < Threads[max].Item1)
                    )
                    )
                    )
                {
                    max = l;


                }
                long r = RightChild(index);
                if (
                    (r < MaxSize)
                   &&
                   (
                   (Threads[r].Item2 < Threads[max].Item2)
                   ||
                   (
                   (Threads[r].Item2 == Threads[max].Item2)
                   && (Threads[r].Item1 < Threads[max].Item1)
                   )
                   )
                   )

                    max = r;
                if (index != max)
                {
                    Swap(index, max);
                    SiftDown(max);
                }

            }
            public void ChangePriority(long index, (long, long) priority)
            {
                (long, long) oldp = Threads[index];
                Threads[index] = priority;
                if ((priority.Item2 < oldp.Item2) || ((priority.Item2 == oldp.Item2)
                    && (priority.Item1 < oldp.Item1)))

                {
                    SiftUp(index);
                }
                if ((priority.Item2 > oldp.Item2) || ((priority.Item2 == oldp.Item2)
                    && (priority.Item1 > oldp.Item1)))
                    SiftDown(index);
            }
            private void Swap(long a, long b)
            {
                var tmp = Threads[a];
                Threads[a] = Threads[b];
                Threads[b] = tmp;
            }
        }

    }

}
