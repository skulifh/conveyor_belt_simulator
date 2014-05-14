using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;
using System.Threading;

namespace UnitTest.ModelTests.LuggageProcessing
{
    [TestClass]
    public class SortingForwarderTest
    {
        [TestMethod]
        public void SortingForwarderTest1()
        {
            List<IRole> roles = new List<IRole>();
            roles.Add(new LoaderRole());
            Personnel p1 = new Personnel(2, roles);
            List<Personnel> pl = new List<Personnel>();
            PersonnelController pc = new PersonnelController(pl);
            List<IProblem> problems = new List<IProblem>();
            problems.Add(new Stuck(0, pc));
            Airplane ap = new Airplane(problems, 2);

            ILuggageQueue queue = new FIFOQueue();
            bool pass1 = queue.Count() == 0;
            queue.enqueueLuggage(1, new LuggageBag(ap));
            bool pass2 = queue.Count() == 1;
            
            List<IComponent> nextComponents = new List<IComponent>();
            nextComponents.Add(ap);
            SortingForwarder s = new SortingForwarder(queue,nextComponents);

            Thread.Sleep(1000);
            s.processLuggage(new LuggageBag(ap));
            bool pass3 = queue.Count() == 0;

            Assert.IsTrue(pass1);
            Assert.IsTrue(pass2);
            Assert.IsTrue(pass3);
        }
    }
}
