using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class SortingMachineTest
    {
        [TestMethod]
        public void testSortingMachineTest()
       { 
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            SortingMachine sm = new SortingMachine(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(sm.name, "Sorting machine number: " + id.ToString());

            Assert.AreEqual(sm.stuck, false);
            IComponent destination = sm;
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
            sm.EnqueueLuggage(lb);
            Assert.AreEqual(sm.Count(), 1);

            s = new Stuck(100, pc);
            problems.Add(s);
            sm.EnqueueLuggage(lb);
            Assert.AreEqual(sm.Count(), 1);

            //DequeLuggage()

            //AddNextComponent()
            try
            {
                sm.addNextComponent(sm);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            //InAndOutCounters()
            Assert.AreEqual(sm.InAndOutCounters().Item1, 2);


            //GetSinks()
            Assert.AreEqual(sm.getSinks().Count, 1);
            **/
        }
    }
}
