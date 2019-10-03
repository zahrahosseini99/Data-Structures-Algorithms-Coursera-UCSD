using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {


            int index1 = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[index1])
                {
                    index1 = i;

                }

            }

            int index2 = 0;
            if (index2 == index1)
                index2++;
            for (int j = 1; j < numbers.Length; j++)
            {

                if (j != index1)
                {
                    if (numbers[j] > numbers[index2])
                    {

                        index2 = j;

                    }

                }

            }


            return numbers[index1] * numbers[index2];
        }
    }
}
