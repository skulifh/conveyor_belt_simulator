using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.PersonnelHandling;
using System.Collections.Generic;

namespace UnitTest.ModelTests.PersonnelHandling
{
    [TestClass]
    public class PersonnelTest
    {
        [TestMethod]
        public void PersonnelTest1()
        {
            List<IRole> roles = new List<IRole>();
            roles.Add(new XRayRole());
            Personnel p1 = new Personnel(1,roles);
            bool pass1 = roles == p1.get_roles();
            
            IRole loaderrole = new LoaderRole();
            roles.Add(loaderrole);
            p1.add_role(loaderrole);
            bool pass2 = roles == p1.get_roles();

            roles.Remove(loaderrole);
            p1.remove_role(new LoaderRole());
            p1.add_role(loaderrole);
            bool pass3 = roles == p1.get_roles();

            Assert.IsTrue(pass1);
            Assert.IsTrue(pass2);
            Assert.IsTrue(pass3);
        }
    }
}
