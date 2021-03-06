﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.PersonnelHandling;
using System.Collections.Generic;

namespace UnitTest.ModelTests.Problem
{
    [TestClass]
    public class StuckTest
    {
        [TestMethod, Timeout(1000)]
        public void StuckTest1()
        {
            List<Personnel> plist = new List<Personnel>();
            List<IRole> roles = new List<IRole>();
            roles.Add(new StuckLuggageRole());
            Personnel p1 = new Personnel(1, roles);
            plist.Add(p1);
            PersonnelController pc = new PersonnelController(plist);
            
            Stuck s = new Stuck(0,pc);
            bool fail1 = s.Fail();

            s = new Stuck(100, pc);
            bool fail2 = s.Fail();

            
            bool fail3 = false;
            try
            {
                s = new Stuck(-1, pc);
                s.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    fail3 = true;
            }


            bool fail4 = false;
            try
            {
                s = new Stuck(101, pc);
                s.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    fail4 = true;
            }

            //s.HandleProblem();

            Assert.IsFalse(fail1);
            Assert.IsTrue(fail2);
            Assert.IsTrue(fail3);
            Assert.IsTrue(fail4);
        }
    }
}
