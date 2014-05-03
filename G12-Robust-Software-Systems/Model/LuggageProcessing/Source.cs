using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class Source : ILuggageProcessor
    {
        private double distributionInput;
        private ILuggageQueue queue;
        private int dequeueDeltaMiliSeconds;
        private int executionTime;
        public Source(double distributionInput, int executionTime, ILuggageQueue queue, int dequeueDeltaMiliSeconds)
        {
            this.distributionInput = distributionInput;
            this.queue = queue;
            this.dequeueDeltaMiliSeconds = dequeueDeltaMiliSeconds;
            this.executionTime = executionTime;
        }

        public void processLuggage(LuggageBag luggage)
        {
            Genpop.GetBags(this.executionTime, this.distributionInput);
            while (true){
                //this.queue.enqueueLuggage(this.dequeueDeltaMiliSeconds);
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
