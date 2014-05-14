using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.PersonnelHandling;

namespace UnitTest.ModelTests.PersonnelHandling
{
    [TestClass]
    public class LoaderRoleTest
    {
        [TestMethod]
        public void LoaderRoleTest1()
        {
            LoaderRole role = new LoaderRole();
            bool pass1 = role.Equals(new LoaderRole());

            Assert.IsTrue(pass1);
        }
    }
}
