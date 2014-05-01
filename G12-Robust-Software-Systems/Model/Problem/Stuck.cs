using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model
{
    class Stuck : IProblem
    {
        private double stuck_constant;

        public Stuck(double stuck_constant)
        {
            this.stuck_constant = stuck_constant;
        }
        public bool Fail()
        {
            return Simulation.Genpop.Failure(stuck_constant);
        }
    }
}
