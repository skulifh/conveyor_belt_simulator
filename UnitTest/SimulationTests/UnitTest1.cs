﻿using System;
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
            int airplanesCount = 5;
            int checkinsCount = 12;
            int beltsCount = 9;
            int xraysCount = 4;

            Initiator parser = new Initiator("../../../Files/system.txt", "../../../Files/scenario.txt");
            
            int trueAirplanesCount = parser.airplanes.Count;
            int trueCheckinsCount = parser.checkins.Count;
            int trueBeltsCount = parser.belts.Count;
            int trueXraysCount = parser.xrays.Count;

            Assert.AreEqual(airplanesCount, trueAirplanesCount);
            Assert.AreEqual(checkinsCount, trueCheckinsCount);
            Assert.AreEqual(beltsCount, trueBeltsCount);
            Assert.AreEqual(xraysCount, trueXraysCount);
        }
    }
}
