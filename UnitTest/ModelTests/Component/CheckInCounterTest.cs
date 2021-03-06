﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model;
using System.Collections.Generic;
using System;

namespace UnitTest.ModelTests
{
    [TestClass]
    public class CheckInCounterTest
    {
        [TestMethod]
        public void testCheckInCounterConstructor() 
        {
            List<Tuple<int, LuggageBag>> luggageAndDequeueDelta = new List<Tuple<int,LuggageBag>>();
            List<IProblem> problems = new List<IProblem>();
            int id = 0;
            IComponent destination = new Airplane(problems, id);
            LuggageBag lb = new LuggageBag(destination);

            luggageAndDequeueDelta.Add(Tuple.Create(1, lb));
            CheckInCounter cic = new CheckInCounter(luggageAndDequeueDelta, problems, id);
            Assert.AreEqual(cic.name, "Check in number: "+id.ToString());
            
            bool fail1 = true;
            try { 
                cic.getSinks();
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    fail1 = false;
            }
            Assert.IsTrue(fail1);

        }
    }
}
