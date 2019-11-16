using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            long numsCount = (expression.Length + 1) / 2;
            var op = new List<string>();
            var nums = new List<long>();
            foreach (var c in expression)
            {
                if (char.IsDigit(c))
                    nums.Add(long.Parse(c.ToString()));
                else
                    op.Add(c.ToString());
            }
            return Parentheses(nums.ToArray(), op, numsCount);


        }
       public long Parentheses(long [] nums, List<string> op,long numsCount)
        {
            var maxtabel = new long[numsCount, numsCount];
            var mintabel = new long[numsCount, numsCount];
            
            for(int i = 0; i < numsCount; i++)
            {
                maxtabel[i, i] = nums[i];
                mintabel[i, i] = nums[i];
                
            }
            for (int s =1; s < numsCount ; s++)
            {
                for (int i = 0; i < numsCount - s; i++)
                {
                    int j = i+s;
                   
                    var res = MinAndMax(maxtabel, mintabel, i, j, op);
                    mintabel[i, j] = res[0];
                    maxtabel[i, j] = res[1];
                }
            }
            return maxtabel[0, numsCount -1];
        }

        private long[] MinAndMax(long[,] M, long[,] m,int i,int j, List<string> op)
        {
            long a, b, c, d;
            var res = new long[2];
            long min = int.MaxValue;
            long max = int.MinValue;
            for(int k = i; k <= j - 1; k++)
            {
                a = Detect(M[i, k], M[k + 1, j], op[k]);
                b = Detect(M[i, k],m[k + 1, j], op[k]);
                c= Detect(m[i, k], M[k + 1, j], op[k]);
                d= Detect(m[i, k], m[k + 1, j], op[k]);
                min = MinofMin(min, a, b, c, d);
                max = MaxOfMax(max, a, b, c, d);
            }
            res[0] = min;
            res[1] = max;
            return res;
        }
        public long Detect(long a,long b, string op)
        {
            if (op =="*")
                return a * b;
            if (op == "+")
                return a + b;
            else
                return a - b;  
        }
        public long MinofMin(long a,long b,long c,long d,long e)
            
        {
            return Math.Min(Math.Min(a, b), Math.Min(Math.Min(c, d), e));
        }
        public long MaxOfMax(long a, long b, long c, long d, long e)

        {
            return Math.Max(Math.Max(a, b), Math.Max(Math.Max(c, d), e));
        }
    }
}
