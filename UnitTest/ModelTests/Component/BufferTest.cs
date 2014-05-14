using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class BufferTest
    {
        [TestMethod]
        public void testBufferConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            List<IProblem> problems = new List<IProblem>();
            int id = 0;
            G12_Robust_Software_Systems.Model.Components.Buffer buf = new G12_Robust_Software_Systems.Model.Components.Buffer(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(buf.name, "Buffer number: " + id.ToString());


            Assert.AreEqual(buf.stuck, false);
            IComponent destination = buf;
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
            buf.EnqueueLuggage(lb);
            Assert.AreEqual(buf.Count(), 1);

            s = new Stuck(100, pc);
            problems.Add(s);
            buf.EnqueueLuggage(lb);
            Assert.AreEqual(buf.Count(), 1);

            //AddNextComponent()
            try
            {
                buf.addNextComponent(buf);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            //InAndOutCounters()
            Assert.AreEqual(buf.InAndOutCounters().Item1, 2);


            //GetSinks()
            Assert.AreEqual(buf.getSinks().Count, 1);
            **/
        }
    }
}
