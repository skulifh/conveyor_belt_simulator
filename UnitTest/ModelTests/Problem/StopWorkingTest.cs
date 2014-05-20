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

            sw = new StopWorking(-1);

            bool fail3 = false;
            try
            {
                sw.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    fail3 = true;
            }

            sw = new StopWorking(101);

            bool fail4 = false;
            try
            {
                sw.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    fail4 = true;
            }

            Assert.IsFalse(fail1);
            Assert.IsTrue(fail2);
            Assert.IsTrue(fail3);
            Assert.IsTrue(fail4);
        }
    }
}
