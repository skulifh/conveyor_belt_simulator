using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class ConveyorBeltTest
    {
        [TestMethod]
        public void testConveyorBeltConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            ConveyorBelt cb = new ConveyorBelt(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(cb.name, "Conveyor belt number:" + id.ToString());
        }
    }
}
