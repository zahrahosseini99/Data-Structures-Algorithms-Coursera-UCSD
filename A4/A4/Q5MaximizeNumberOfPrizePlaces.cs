using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);


        public virtual long[] Solve(long n)
        {
            var array = new List<long>();
            int i = 1;
            while (n >= i)
            {
                n = n - i;

                if (n > i)
                    array.Add(i);
                else
                    array.Add(n + i);
                i++;
            }
            return array.ToArray();
        }



    }
}

