using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class XrayTest
    {
        [TestMethod]
        public void testXrayConstructor()
        {
            int dequeueDeltaMiliSeconds = 0;
            int id = 0;
            List<IProblem> problems = new List<IProblem>();
            XRayMachine xray = new XRayMachine(dequeueDeltaMiliSeconds, problems, id);
            Assert.AreEqual(xray.name, "X-ray machine number: " + id.ToString());

            Assert.AreEqual(xray.stuck, false);
            IComponent destination = xray;
            LuggageBag lb = new LuggageBag(destination);

            try {
                xray.getSinks();
            }
            catch(NullReferenceException)
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
            xray.EnqueueLuggage(lb);
            Assert.AreEqual(xray.Count(), 1);

            s = new Stuck(100, pc);
            problems.Add(s);
            xray.EnqueueLuggage(lb);
            Assert.AreEqual(xray.Count(), 1);

            //AddNextComponent()
            try
            {
                xray.addNextComponent(xray);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            //InAndOutCounters()
            Assert.AreEqual(xray.InAndOutCounters().Item1, 2);


            //GetSinks()
            Assert.AreEqual(xray.getSinks().Count, 1); 
            **/
        }
    }
}
