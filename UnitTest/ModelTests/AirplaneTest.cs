using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using System.Collections.Generic;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class AirplaneTest
    {
        [TestMethod]
        public void testAirplaneConstructor() 
        {
            List<IProblem> problems = new List<IProblem>();
            int id= 0;
            Airplane ap = new Airplane(problems, id);
            Assert.AreEqual(ap.name, "Airplane number: "+id.ToString());
        }
    }
}
