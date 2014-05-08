using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Requires(distributionInput != null, "distributionInput cannot be null");
            Contract.Requires(executionTime != null, "executionTime cannot be null");
            Contract.Requires(queue != null, "queue cannot be null");
            Contract.Requires(dequeueDeltaMiliSeconds >= 0, "dequeueDeltaMiliSeconds cannot be less than zero");

            this.distributionInput = distributionInput;
            this.queue = queue;
            this.dequeueDeltaMiliSeconds = dequeueDeltaMiliSeconds;
            this.executionTime = executionTime;
        }

        public void processLuggage(LuggageBag luggage)
        {
            Contract.Requires(luggage != null, "luggage cannot be null");

            Genpop.GetBags(this.executionTime, this.distributionInput);
            while (true){
                //this.queue.enqueueLuggage(this.dequeueDeltaMiliSeconds);
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
