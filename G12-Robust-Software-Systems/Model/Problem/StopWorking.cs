using System;
using System.Collections.Generic;
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
            this.stop_constant = stop_constant;
        }
        public bool Fail()
        {
           return Simulation.Genpop.Failure(stop_constant);  
        }
    }
}
