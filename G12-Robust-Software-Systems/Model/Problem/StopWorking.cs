using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model
{
    public class StopWorking : IProblem
    {
        private double stop_constant;
        private const int TIMETOPROCESS = 5000;
        public StopWorking(double stop_constant)
        {
            Contract.Requires(stop_constant >= 0 && stop_constant <= 100, "Wrong value for stuck constant");
            this.stop_constant = stop_constant;
        }
        public bool Fail()
        {
           return Simulation.Statistics.Failure(stop_constant);  
        }

        public void HandleProblem()
        {
            long end_time = DateTime.Now.Ticks + 10000 * TIMETOPROCESS;
            while (end_time > DateTime.Now.Ticks) 
            {
                Thread.Sleep(10);
            }
        }
    }
}
