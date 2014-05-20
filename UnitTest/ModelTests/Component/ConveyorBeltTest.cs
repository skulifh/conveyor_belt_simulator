using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class ConveyorBeltTest
    {
        [TestMethod]
        public void testConveyorBeltConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            ConveyorBelt cb = new ConveyorBelt(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(cb.name, "Conveyor belt number:" + id.ToString());

            Assert.AreEqual(cb.stuck, false);
            IComponent destination = cb;
            LuggageBag lb = new LuggageBag(destination);

            try {
                cb.getSinks();
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(false);
            }


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
            cb.EnqueueLuggage(lb);
            Assert.AreEqual(1, cb.Count());

            s = new Stuck(100, pc);
            problems.Add(s);
            cb.EnqueueLuggage(lb);
            Assert.AreEqual(2, cb.Count());

            //DequeLuggage()

            //AddNextComponent()
            try
            {
                cb.addNextComponent(cb);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            //InAndOutCounters()
            Assert.AreEqual(cb.InAndOutCounters().Item1, 2);


            //GetSinks()

            Assert.AreEqual(cb.getSinks().Count, 1);
            **/
        }
    }
}
