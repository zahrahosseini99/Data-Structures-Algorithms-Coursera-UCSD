using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A5
{
    public class Q3ImprovingQuickSort : Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {

            QuickSort(a, 0, n - 1);
            return a;
        }
        static long[] partition(long[] a, long low, long high)
        {
            List<long> pivots = new List<long>();

            long pivot = a[low];
            long m1 = low + 1;
            long m2 = low;

            for (long i = low + 1; i <= high; i++)
            {

                if (a[i] <= pivot)
                {
                    m2++;

                    (a[i], a[m2]) = (a[m2], a[i]);
                    if (a[m2] < pivot)
                    {
                        (a[m1], a[m2]) = (a[m2], a[m1]);
                        m1++;
                    }

                }
            }

            (a[low], a[m1 - 1]) = (a[m1 - 1], a[low]);
            pivots.Add(m1);
            pivots.Add(m2);

            return pivots.ToArray();
        }

        static void QuickSort(long[] a, long low, long high)
        {
            if (low < high)
            {
                long[] pivots = partition(a, low, high);

                QuickSort(a, low, pivots[0] - 1);
                QuickSort(a, pivots[1] + 1, high);
            }
        }

    }
}
