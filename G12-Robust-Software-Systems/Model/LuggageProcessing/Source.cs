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
        public Source(double distributionInput, ILuggageQueue queue, int dequeueDeltaMiliSeconds)
        {
            this.distributionInput = distributionInput;
            this.queue = queue;
            this.dequeueDeltaMiliSeconds = dequeueDeltaMiliSeconds;
        }

        public void processLuggage()
        {
            while (true){
                this.queue.enqueueLuggage(this.dequeueDeltaMiliSeconds);
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
