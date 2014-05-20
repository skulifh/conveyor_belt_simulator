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
            
            bool fail1 = false;
            try
            {
                p1.add_role(new LoaderRole());
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    fail1 = true;
                
            }
            

            Assert.IsTrue(pass1);
            Assert.IsTrue(pass2);
            Assert.IsTrue(pass3);
            Assert.IsTrue(fail1);
        }

        [TestMethod]
        public void PersonnelTest2()
        {
            List<IRole> roles = new List<IRole>();

            Console.WriteLine("Add LoaderRole");
            roles.Add(new LoaderRole());

            Console.WriteLine("Add StuckLuggageRole");
            roles.Add(new StuckLuggageRole());

            Personnel p = new Personnel(1, roles);

            Console.WriteLine("Roles:");
            foreach (IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }

            p.remove_role(new StuckLuggageRole());
            Console.WriteLine("Removed StuckLuggageRole");

            Console.WriteLine("Roles:");
            foreach (IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }

            Console.WriteLine("Add XRayRole");
            p.add_role(new XRayRole());

            Console.WriteLine("Roles:");
            foreach (IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }


        }
    }
}
