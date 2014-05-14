using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests.PersonnelHandling
{
    [TestClass]
    public class PersonnelControllerTest
    {
        [TestMethod]
        public void PersonnelControllerTest1()
        {
            List<IRole> roles1 = new List<IRole>();
            roles1.Add(new LoaderRole());
            Personnel p1 = new Personnel(1, roles1);

            List<Personnel> personnel = new List<Personnel>();
            personnel.Add(p1);
            PersonnelController pc = new PersonnelController(personnel);

            List<IRole> roles2 = new List<IRole>();
            roles2.Add(new StuckLuggageRole());
            Personnel p2 = new Personnel(2, roles2);

            pc.returnPerson(p2);
            Personnel p3 = pc.acquirePersonWithRole(new StuckLuggageRole());

            bool pass1 = p2 == p3;

            Assert.IsNotNull(p3);
            Assert.IsTrue(pass1);
        }
    }
}
