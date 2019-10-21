﻿using System;
using System.Collections.Generic;
using TestCommon;

namespace E1a
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


        public virtual long Solve(long nr, long dr)
        {
            double kasr = (double)nr / (double)dr;
            double sum = 0;
            long i = 1;
            if (nr % dr == 0)
                return 1;
            while (sum<kasr)
            {
                double k = (double)((double)1 / (double)i);
                if(!(k> (double)(kasr-sum)))
                sum += (double)((double)1 / (double)i);
                if (sum == kasr)
                    break;
                i++;
            }
            return i;
        }
       
    }
}
