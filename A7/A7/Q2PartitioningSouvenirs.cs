using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;
namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            if (EqualSum(souvenirs, souvenirsCount))
                return 1;
            else
                return 0;

        }



        static bool EqualSum(long[] souvenirs, long souvenirsCount)
        {

            long sum = 0;
            long i, j;

            sum = souvenirs.Sum();
            bool[,] tabel = new bool[sum / 3 + 1, souvenirsCount + 1];
            if (souvenirsCount < 3)
                return false;
            if (sum % 3 != 0)
                return false;
            for (i = 1; i <= (int)(sum / 3); i++)
                tabel[i, 0] = false;

            for (i = 0; i <= souvenirsCount; i++)
                tabel[0, i] = true;


            for (i = 1; i <= (int)(sum / 3); i++)
            {
                for (j = 1; j <= souvenirsCount; j++)
                {
                    tabel[i, j] = tabel[i, j - 1];
                    if (i >= souvenirs[j - 1])
                    {

                        tabel[i, j] =
                            tabel[i, j - 1]
                            || tabel[i - souvenirs[j - 1], j - 1];
                    }
                }
            }

            return tabel[sum / 3, souvenirsCount];
        }


      


    }
}
