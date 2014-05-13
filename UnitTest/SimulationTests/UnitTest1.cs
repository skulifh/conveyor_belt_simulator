using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Simulation;

namespace UnitTest.SimulationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParserTest1()
        {
            int airplanesCount = 3;
            int checkinsCount = 3;
            int beltsCount = 4;
            int xraysCount = 2;

            Parser parser = new Parser();
            
            int trueAirplanesCount = parser.airplanes.Count;
            int trueCheckinsCount = parser.checkins.Count;
            int trueBeltsCount = parser.belts.Count;
            int trueXraysCount = parser.xrays.Count;

            Assert.IsTrue(airplanesCount == trueAirplanesCount);
            Assert.IsTrue(checkinsCount == trueCheckinsCount);
            Assert.IsTrue(beltsCount == trueBeltsCount);
            Assert.IsTrue(xraysCount == trueXraysCount);
        }
    }
}
