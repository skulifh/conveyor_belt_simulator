using G12_Robust_Software_Systems.Model.PersonnelHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model
{
    public class Stuck : IProblem
    {
        private double stuck_constant;
        private PersonnelController pc;
        private const int TIMETOPROCESS = 5000;

        public Stuck(double stuck_constant, PersonnelController pc)
        {
            Contract.Requires(stuck_constant >= 0 && stuck_constant <= 100, "Wrong value for stuck constant");
            this.stuck_constant = stuck_constant;
            this.pc = pc;
        }
        public bool Fail()
        {
            return Simulation.Genpop.Failure(stuck_constant);
        }

        public void HandleProblem()
        {
            StuckLuggageRole neededRole = new StuckLuggageRole();
            Personnel person = null;
            // Spin while no available person
            while (person == null)
            {
                Thread.Sleep(10);
                person = pc.acquirePersonWithRole(neededRole);
            }
            long end_time = DateTime.Now.Ticks + 10000 * TIMETOPROCESS;
            while (end_time > DateTime.Now.Ticks) 
            {
                Thread.Sleep(10);
            }
            pc.returnPerson(person);
        }
    }
}
