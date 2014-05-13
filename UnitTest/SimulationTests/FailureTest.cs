using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Simulation;

namespace UnitTest.SimulationTests
{
    [TestClass]
    public class FailureTest
    {
        [TestMethod]
        public void FailureTest1()
        {
            double trueRate = 50;
            double falseRate = 100 - trueRate;
            double trueRateDecimal = trueRate / 100;
            double falseRateDecimal = falseRate / 100;
            int trueCounter = 0;
            int falseCounter = 0;
            int noOfRuns = 100000;
            double estimatedFailure = noOfRuns * trueRateDecimal;

            for (int i = 0; i < noOfRuns; i++)
            {
                bool result = Genpop.Failure(trueRate);
                if (result == true)
                    trueCounter += 1;
                if (result == false)
                    falseCounter += 1;
            }

            Console.WriteLine("trueCounter : " + trueCounter);
            Console.WriteLine("falseCounter : " + falseCounter);
            Console.WriteLine((Math.Abs((noOfRuns * trueRateDecimal) - trueCounter)));
            Console.WriteLine((Math.Abs((noOfRuns * trueRateDecimal) - trueCounter)));


            Console.WriteLine("Variance true: " + 100 * ((Math.Abs((noOfRuns * trueRateDecimal) - trueCounter)) / (noOfRuns * trueRateDecimal)));

            Console.WriteLine("Variance false: " + 100 * ((Math.Abs((noOfRuns * falseRateDecimal) - falseCounter)) / (noOfRuns * falseRateDecimal)));

            double varianceAllowed = 0.1;

            //Checking if the counters are within 10% variance of expected value
            Assert.IsTrue(Math.Abs((noOfRuns * trueRateDecimal) - trueCounter) < ((noOfRuns * trueRateDecimal) * varianceAllowed));
            Assert.IsTrue(Math.Abs((noOfRuns * falseRateDecimal) - falseCounter) < ((noOfRuns * falseRateDecimal) * varianceAllowed));
        }

        [TestMethod]
        public void FailureTest2()
        {
            double trueRate = 5;
            double falseRate = 100 - trueRate;
            double trueRateDecimal = trueRate / 100;
            double falseRateDecimal = falseRate / 100;
            int trueCounter = 0;
            int falseCounter = 0;
            int noOfRuns = 100000;
            double estimatedFailure = noOfRuns * trueRateDecimal;

            for (int i = 0; i < noOfRuns; i++)
            {
                bool result = Genpop.Failure(trueRate);
                if (result == true)
                    trueCounter += 1;
                if (result == false)
                    falseCounter += 1;
            }

            Console.WriteLine("trueCounter : " + trueCounter);
            Console.WriteLine("falseCounter : " + falseCounter);
            Console.WriteLine((Math.Abs((noOfRuns * trueRateDecimal) - trueCounter)));
            Console.WriteLine((Math.Abs((noOfRuns * trueRateDecimal) - trueCounter)));


            Console.WriteLine("Variance true: " + 100 * ((Math.Abs((noOfRuns * trueRateDecimal) - trueCounter)) / (noOfRuns * trueRateDecimal)));

            Console.WriteLine("Variance false: " + 100 * ((Math.Abs((noOfRuns * falseRateDecimal) - falseCounter)) / (noOfRuns * falseRateDecimal)));

            double varianceAllowed = 0.1;

            //Checking if the counters are within 10% variance of expected value
            Assert.IsTrue(Math.Abs((noOfRuns * trueRateDecimal) - trueCounter) < ((noOfRuns * trueRateDecimal) * varianceAllowed));
            Assert.IsTrue(Math.Abs((noOfRuns * falseRateDecimal) - falseCounter) < ((noOfRuns * falseRateDecimal) * varianceAllowed));
        }
    }
}
