using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.Problem
{
    [TestClass]
    public class StopWorkingTest
    {
        

        [TestMethod]
        public void StopWorkingTest1()
        {
            StopWorking sw = new StopWorking(0);
            bool fail1 = sw.Fail();

            sw = new StopWorking(100);
            bool fail2 = sw.Fail();

            Assert.IsFalse(fail1);
            Assert.IsTrue(fail2);
        }
    }
}
