using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class XrayTest
    {
        [TestMethod]
        public void testXrayConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            XRayMachine xray = new XRayMachine(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(xray.name, "X-ray machine number: " + id.ToString());
        }
    }
}
