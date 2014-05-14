using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.LuggageProcessing;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using System.Collections.Generic;
using System.Threading;

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

        [TestMethod]
        public void testEnqueueAndDequeueLuggage()
        {
            FIFOQueue queue = new FIFOQueue();
            List<LuggageBag> returnedLuggage = queue.checkLuggageQueue();
            Assert.AreEqual(returnedLuggage.Count, 0);
            queue.enqueueLuggage(1, new LuggageBag(new Airplane(new List<IProblem>(), 1)));
            Thread.Sleep(1000);
            returnedLuggage = queue.checkLuggageQueue();
            Assert.AreEqual(returnedLuggage.Count, 1);
        }
    }
}
