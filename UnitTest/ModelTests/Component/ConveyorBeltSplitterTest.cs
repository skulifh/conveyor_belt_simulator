using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class ConveyorBeltSplitterTest
    {
        [TestMethod]
        public void testConveyorBeltSplitterConstructor()
        {
            int dequeueDeltaMiliSeconds = 1000;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            ConveyorBeltSplitter cbs = new ConveyorBeltSplitter(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(cbs.name, "Conveyor belt splitter number: " + id.ToString());

            Assert.AreEqual(cbs.stuck, false);
            IComponent destination = cbs;
            LuggageBag lb = new LuggageBag(destination);
            
            // Check count() and enqueluggage with problem and without problem
            List<Personnel> plist = new List<Personnel>();
            List<IRole> roles = new List<IRole>();
            roles.Add(new StuckLuggageRole());
            Personnel p1 = new Personnel(1, roles);
            plist.Add(p1);
            PersonnelController pc = new PersonnelController(plist);

            Stuck s = new Stuck(0, pc);
            problems.Add(s);
            cbs.EnqueueLuggage(lb);
            /**
            Assert.AreEqual(1,cbs.Count());

            s = new Stuck(100, pc);
            problems.Add(s);
            cbs.EnqueueLuggage(lb);
            Assert.AreEqual(2,cbs.Count());

            try
            {
                cbs.addNextComponent(cbs);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            Assert.AreEqual(cbs.getSinks().Count, 1);**/
        }
    }
}
