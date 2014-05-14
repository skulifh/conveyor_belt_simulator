using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class SortingMachineTest
    {
        [TestMethod]
        public void testSortingMachineTest()
       { 
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            SortingMachine sm = new SortingMachine(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(sm.name, "Sorting machine number: " + id.ToString());
        }
    }
}
