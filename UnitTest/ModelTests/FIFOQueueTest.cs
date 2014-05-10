using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.LuggageProcessing;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class FIFOQueueTest
    {
        [TestMethod]
        public void testConstructor()
        {
            FIFOQueue queue = new FIFOQueue();
        }
    }
}
