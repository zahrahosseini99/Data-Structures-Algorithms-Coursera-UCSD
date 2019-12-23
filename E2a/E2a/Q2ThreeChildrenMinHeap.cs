using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2a
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        public static long Parent(long index) =>  index/2;
        public static long LeftChild(long index) => 3 * index + 1;
        public static long MidChild(long index) => 3 * index + 2;
        public static long RightChild(long index) => 3 * index + 3;
        public class Heap
        {
            public long size;
            public long[] H;
            public Heap(long _size, long[] arr)
            {
                size = _size;
                H = arr;
            }
           
            public void SiftDown(long i)
            {
                long maxInedex = i;
                long l = LeftChild(i);
                if (l < size && H[l] < H[maxInedex])
                    maxInedex = l;
                long r = RightChild(i);
                if (r < size && H[r] < H[maxInedex])
                    maxInedex = r;
                long m = MidChild(i);
                if (m < size && H[m] < H[maxInedex])
                    maxInedex = m;
                if (i != maxInedex)
                {
                    (H[i], H[maxInedex]) = (H[maxInedex], H[i]);
                    SiftDown(maxInedex);
                }

            }
            public void SiftUp(long i)
            {
                while(i>1 && H[Parent(i)]> H[i])
                {
                    (H[Parent(i)], H[i]) = (H[i], H[Parent(i)]);
                    i = Parent(i);
                }
            }
        }
        public long[] Solve(
            long n,
            long changeIndex,
            long changeValue,
            long[] heap)
        {
            Heap tree = new Heap(n, heap);
            long a = tree.H[changeIndex];
            tree.H[changeIndex]= tree.H[changeIndex] + changeValue;
            for (int i = 0; i < tree.H.Length; i++)
            {
                if (tree.H[i] < tree.H[Parent(i)])
                    tree.SiftDown(Parent(i));
               

            }
            return tree.H;
        }

    }
}
