using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class ConveyorBeltSplitterTest
    {
        [TestMethod]
        public void testConveyorBeltSplitterConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            ConveyorBeltSplitter cbs = new ConveyorBeltSplitter(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(cbs.name, "Conveyor belt splitter number: " + id.ToString());
        }
    }
}
