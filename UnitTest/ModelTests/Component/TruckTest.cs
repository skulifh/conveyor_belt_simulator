using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class TruckTest
    {
        [TestMethod]
        public void testTruckConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            Truck truck = new Truck(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(truck.name, "Truck number: " + id.ToString());

            Assert.AreEqual(truck.stuck, false);
            IComponent destination = truck;
            LuggageBag lb = new LuggageBag(destination);
            /**
            // Check count() and enqueluggage with problem and without problem
            List<Personnel> plist = new List<Personnel>();
            List<IRole> roles = new List<IRole>();
            roles.Add(new StuckLuggageRole());
            Personnel p1 = new Personnel(1, roles);
            plist.Add(p1);
            PersonnelController pc = new PersonnelController(plist);

            Stuck s = new Stuck(0, pc);
            problems.Add(s);
            truck.EnqueueLuggage(lb);
            Assert.AreEqual(truck.Count(), 1);

            s = new Stuck(100, pc);
            problems.Add(s);
            truck.EnqueueLuggage(lb);
            Assert.AreEqual(truck.Count(), 1);

            try
            {
                truck.addNextComponent(truck);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            Assert.AreEqual(truck.InAndOutCounters().Item1, 2);

            Assert.AreEqual(truck.getSinks().Count, 1);
            **/
        }
    }
}
