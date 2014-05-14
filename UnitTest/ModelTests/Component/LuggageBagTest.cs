using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class LuggageBagTest
    {
        [TestMethod]
        public void testLuggageBagConstructor()
        {
            List<IProblem> problems = new List<IProblem>();
            int id= 0;
            IComponent c_destination = new Airplane(problems, id);
            LuggageBag lb = new LuggageBag(c_destination);
            Assert.AreEqual(lb.destination, c_destination);
        }
    }
}
