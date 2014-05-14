using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests.Problem
{
    [TestClass]
    public class StopWorkingTest
    {


        [TestMethod, Timeout(1000)]
        public void StopWorkingTest1()
        {
            StopWorking sw = new StopWorking(0);
            bool fail1 = sw.Fail();

            sw = new StopWorking(100);
            bool fail2 = sw.Fail();

            sw.HandleProblem();

            Assert.IsFalse(fail1);
            Assert.IsTrue(fail2);
        }
    }
}
