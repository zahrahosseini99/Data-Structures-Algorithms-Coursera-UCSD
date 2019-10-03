﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Q1NaiveMaxPairWise test1 = new Q1NaiveMaxPairWise("");
            Q2FastMaxPairWise test2 = new Q2FastMaxPairWise("");
          
            long[] random = new long[50];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds<5000)
            {
                
                Random randNum = new Random();
                for (int i = 0; i < random.Length; i++)
                {
                    int number = randNum.Next(0, int.MaxValue);
                    if (!random.Contains(number))
                    random[i] = number;
                }
                Assert.AreEqual(test1.Solve(random), test2.Solve(random));
            }
          
            
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}