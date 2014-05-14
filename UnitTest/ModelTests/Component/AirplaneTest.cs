using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model.LuggageProcessing;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

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

            // Constructor()
            Assert.AreEqual(ap.name, "Airplane number: "+id.ToString());
            Assert.AreEqual(ap.initialized, true);
            Assert.AreEqual(ap.stuck, false);
            IComponent destination = ap;
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
            ap.EnqueueLuggage(lb);
            Assert.AreEqual(ap.Count(), 1);

            s = new Stuck(100, pc);
            problems.Add(s);
            ap.EnqueueLuggage(lb);
            Assert.AreEqual(ap.Count(), 1);
            
            //DequeLuggage()
            //ap.DequeueLuggage();
            //Assert.AreEqual(ap.Count(), 0);

            //AddNextComponent()
            try
            {
                ap.addNextComponent(ap);
            }
            catch (NotImplementedException)
            {
                Assert.IsTrue(true);
            }

            //InAndOutCounters()
            Assert.AreEqual(ap.InAndOutCounters().Item1, 2);
            
            
            //GetSinks()
            //Assert.AreEqual(ap.getSinks(), );
            Assert.AreEqual(ap.getSinks().Count, 1);
            //Assert.AreEqual(ap.getSinks().ToString(), "Airplane number: 0");

        }

    }
}
