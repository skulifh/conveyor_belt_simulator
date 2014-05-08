using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model
{
    class StopWorking : IProblem
    {
        private double stop_constant;

        public StopWorking(double stop_constant)
        {
            Contract.Requires(stop_constant >= 0 && stop_constant <= 100, "Wrong value for stuck constant");
            this.stop_constant = stop_constant;
        }
        public bool Fail()
        {
           return Simulation.Genpop.Failure(stop_constant);  
        }
    }
}
