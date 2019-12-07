using System;
using System.Collections.Generic;
using TestCommon;
using System.Linq;
namespace A9

{
    public class Heap
    {
        public long[] H;
        public long Size;
        List<Tuple<long, long>> res = new List<Tuple<long, long>>();
        public Heap(long[] _H, long _size)
        {
            H = _H;
            Size = _size;
        }
        private long LeftChild(long i) => 2 * i + 1;
        private long RightChild(long i) => 2 * i + 2;

        public void SiftDown(long i)
        {
            long maxindex = i;
            long l = LeftChild(i);
            if (l < Size && H[l] < H[maxindex])
            {
                maxindex = l;

            }
            long r = RightChild(i);
            if (r < Size && H[r] < H[maxindex])
            {
                maxindex = r;
            }
            if (i != maxindex)
            {
                res.Add(Tuple.Create(i, maxindex));
                (H[i], H[maxindex]) = (H[maxindex], H[i]);

                SiftDown(maxindex);
            }


        }
        public Tuple<long, long>[] Result()
        {
            for (long i = Size / 2; i > -1; i--)
            {
                SiftDown(i);
            }
            return res.ToArray();
        }
    }
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            Heap example = new Heap(array, array.Length);
            return example.Result();

        }

    }
}
