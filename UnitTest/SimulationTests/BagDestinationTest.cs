using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Simulation;

namespace UnitTest.SimulationTests
{
    [TestClass]
    public class BagDestinationTest
    {
        [TestMethod]
        public void test1()
        {
            int counter0 = 0;
            int counter1 = 0;
            int counter2 = 0;
            int noOfRuns = 100000;
            String bla = Parser.validate();
            Console.WriteLine(bla);

            for (int i = 0; i < noOfRuns; i++)
            {
                int result = Genpop.Runner(0);
                if (result == 0)
                    counter0 += 1;
                if (result == 1)
                    counter1 += 1;
                if (result == 2)
                    counter2 += 1;
            }

            Console.WriteLine("counter0 : " + counter0);
            Console.WriteLine("counter1 : " + counter1);
            Console.WriteLine("counter2 : " + counter2);

            Console.WriteLine("Variance0: " + 100* ((Math.Abs((noOfRuns * 0.25) - counter0)) / (noOfRuns * 0.25)));

            Console.WriteLine("Variance1: " + 100 * ((Math.Abs((noOfRuns * 0.4) - counter1)) / (noOfRuns * 0.4)));

            Console.WriteLine("Variance2: " + 100 * ((Math.Abs((noOfRuns * 0.35) - counter2)) / (noOfRuns * 0.35)));

            double varianceAllowed = 0.1;

            //Checking if the counters are within 10% variance of expected value
            Assert.IsTrue(Math.Abs((noOfRuns * 0.25) - counter0) < (noOfRuns * 0.25) * varianceAllowed);
            Assert.IsTrue(Math.Abs((noOfRuns * 0.4) - counter1) < (noOfRuns * 0.4) * varianceAllowed);
            Assert.IsTrue(Math.Abs((noOfRuns * 0.35) - counter2) < (noOfRuns * 0.35) * varianceAllowed);


        }

        [TestMethod]
        public void test2()
        {
            int counter0 = 0;
            int counter1 = 0;
            int counter2 = 0;
            int noOfRuns = 100000;

            for (int i = 0; i < noOfRuns; i++)
            {
                int result = Genpop.Runner(1);
                if (result == 0)
                    counter0 += 1;
                if (result == 1)
                    counter1 += 1;
                if (result == 2)
                    counter2 += 1;
            }

            Console.WriteLine("counter0 : " + counter0);
            Console.WriteLine("counter1 : " + counter1);
            Console.WriteLine("counter2 : " + counter2);

            Console.WriteLine("Variance0: " + 100 * ((Math.Abs((noOfRuns * 0.30) - counter0)) / (noOfRuns * 0.30)));

            Console.WriteLine("Variance1: " + 100 * ((Math.Abs((noOfRuns * 0.30) - counter1)) / (noOfRuns * 0.30)));

            Console.WriteLine("Variance2: " + 100 * ((Math.Abs((noOfRuns * 0.40) - counter2)) / (noOfRuns * 0.40)));

            double varianceAllowed = 0.1;

            //Checking if the counters are within 10% variance of expected value
            Assert.IsTrue(Math.Abs((noOfRuns * 0.30) - counter0) < (noOfRuns * 0.30) * varianceAllowed);
            Assert.IsTrue(Math.Abs((noOfRuns * 0.30) - counter1) < (noOfRuns * 0.30) * varianceAllowed);
            Assert.IsTrue(Math.Abs((noOfRuns * 0.40) - counter2) < (noOfRuns * 0.40) * varianceAllowed);

        }

        [TestMethod]
        public void test3()
        {
            int counter0 = 0;
            int counter1 = 0;
            int counter2 = 0;
            int noOfRuns = 100000;

            for (int i = 0; i < noOfRuns; i++)
            {
                int result = Genpop.Runner(2);
                if (result == 0)
                    counter0 += 1;
                if (result == 1)
                    counter1 += 1;
                if (result == 2)
                    counter2 += 1;
            }

            Console.WriteLine("counter0 : " + counter0);
            Console.WriteLine("counter1 : " + counter1);
            Console.WriteLine("counter2 : " + counter2);

            Console.WriteLine(counter0 + counter1 + counter2);

            Console.WriteLine("Variance0: " + 100 * ((Math.Abs((noOfRuns * 0.45) - counter0)) / (noOfRuns * 0.45)));

            Console.WriteLine("Variance1: " + 100 * ((Math.Abs((noOfRuns * 0.30) - counter1)) / (noOfRuns * 0.30)));

            Console.WriteLine("Variance2: " + 100 * ((Math.Abs((noOfRuns * 0.25) - counter2)) / (noOfRuns * 0.25)));

            double varianceAllowed = 0.1;

            //Checking if the counters are within 10% variance of expected value
            Assert.IsTrue(Math.Abs((noOfRuns * 0.45) - counter0) < (noOfRuns * 0.45) * varianceAllowed);
            Assert.IsTrue(Math.Abs((noOfRuns * 0.30) - counter1) < (noOfRuns * 0.30) * varianceAllowed);
            Assert.IsTrue(Math.Abs((noOfRuns * 0.25) - counter2) < (noOfRuns * 0.25) * varianceAllowed);


        }
    }
}
