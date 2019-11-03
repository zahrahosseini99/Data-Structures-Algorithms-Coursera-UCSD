using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions : Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            return MergeSort(a, 0, a.Length - 1);
        }


        private long MergeSort(long[] arr, long low, long high)
        {
            long count = 0;
            if (low < high)
            {
                var mid = low + ((high - low) / 2);
                count += MergeSort(arr, low, mid);
                count += MergeSort(arr, mid + 1, high);

                count += Merge(arr, low, mid + 1, high);
            }

            return count;
        }

        private long Merge(long[] a, long low, long mid, long high)
        {
            long count = 0;
            List<long> nums = new List<long>();
            long i = low, j = mid;
            while ((i < mid) && (j <= high))
            {
                if (a[i] <= a[j])
                {
                    nums.Add(a[i]);
                    i++;
                }
                else
                {
                    count += (mid - i);
                    nums.Add(a[j]);
                    j++;
                }
            }

            while (i < mid)
            {
                nums.Add(a[i++]);
            }

            while (j <= high)
            {
                nums.Add(a[j++]);
            }

            long k = low;
            foreach (var n in nums)
            {
                a[k++] = n;
            }

            return count;
        }


    }
}
