using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class TruckTest
    {
        [TestMethod]
        public void testTruckConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            Truck truck = new Truck(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(truck.name, "Truck number: " + id.ToString());
        }
    }
}
