using System;
using System.Collections.Generic;
using TestCommon;

namespace E1c
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            if (nr % dr == 0)
                return 1;
            if (dr % nr == 0)
                return dr / nr;
            if (nr > dr)
                return Solve(nr % dr, dr);
            if (dr > nr)
            {
                long n = dr / nr + 1;
                return Solve(-dr % nr+nr, dr * n);
            }
            return 0;
        }
    }
}
