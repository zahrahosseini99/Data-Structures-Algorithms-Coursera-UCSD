using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {

            Stack<Tuple<char, int>> check = new Stack<Tuple<char, int>>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{' || str[i] == '(' || str[i] == '[')
                {

                    check.Push(Tuple.Create(str[i], i));

                }

                if (str[i] == '}' || str[i] == ')' || str[i] == ']')
                {
                    if (check.Count == 0)
                        return i + 1;
                    else if (!IsBalance(((Tuple<char, int>)check.Pop()).Item1, str[i]))
                    {
                        return i + 1;
                    }


                }

            }
            if (check.Count == 0)
                return -1;
            else
            {
                Tuple<char, int> a = new Tuple<char, int>('a', 0);
                while (check.Count != 0)
                {
                    a = check.Pop();

                }
                return a.Item2 + 1;
            }

        }


        private bool IsBalance(char character1, char character2)
        {
            if ((character1 == '(' && character2 == ')')
                || (character1 == ')' && character2 == '('))
                return true;
            else if ((character1 == '{' && character2 == '}')
                || (character1 == '}' && character2 == '{'))
                return true;
            else if ((character1 == '[' && character2 == ']')
                || (character1 == ']' && character2 == '['))
                return true;
            else
                return false;
        }
    }
}