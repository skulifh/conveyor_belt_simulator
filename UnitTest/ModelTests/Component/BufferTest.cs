using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using System.Collections.Generic;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class BufferTest
    {
        [TestMethod]
        public void testBufferConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            List<IProblem> problems = new List<IProblem>();
            int id = 0;
            G12_Robust_Software_Systems.Model.Components.Buffer buf = new G12_Robust_Software_Systems.Model.Components.Buffer(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(buf.name, "Buffer number: " + id.ToString());
        }
    }
}
