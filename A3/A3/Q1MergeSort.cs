using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            if (n <= 1)
                return a;
            MergeSort(a, 0, n - 1);
            return a;
        }

        public static void MergeSort(long[] array, long low, long high)
        {
            if (low < high)
            {
                long mid = ((low + high) / 2);
                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);
                Merge(array, low, mid, high);
            }
        }


        private static void Merge(long[] array, long low, long mid, long high)
        {

            long left = low;
            long right = mid + 1;
            long[] merge = new long[(high - low) + 1];
            long index = 0;

            while ((left <= mid) && (right <= high))
            {
                if (array[left] < array[right])
                {
                    merge[index] = array[left];
                    left = left + 1;
                }
                else
                {
                    merge[index] = array[right];
                    right = right + 1;
                }
                index = index + 1;
            }

            if (left <= mid)
            {
                while (left <= mid)
                {
                    merge[index] = array[left];
                    left = left + 1;
                    index = index + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    merge[index] = array[right];
                    right = right + 1;
                    index = index + 1;
                }
            }

            for (int i = 0; i < merge.Length; i++)
            {
                array[low + i] = merge[i];
            }

        }


    }
}
