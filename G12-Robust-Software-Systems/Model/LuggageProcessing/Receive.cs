using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    public class Receive : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private int dequeueDeltaMiliSeconds;
        public int LuggageCounter { private set; get; }
        public Receive(ILuggageQueue queue, int dequeueDeltaMiliSeconds)
        {
            Contract.Requires(queue != null, "queue cannot be null");
            Contract.Requires(dequeueDeltaMiliSeconds >= 0, "dequeueDeltaMiliSeconds cannot be less than zero");

            this.LuggageCounter = 0;
            this.queue = queue;
            this.dequeueDeltaMiliSeconds = dequeueDeltaMiliSeconds;
        }

        public void processLuggage(LuggageBag luggage)
        {
            Contract.Requires(luggage != null, "luggage cannot be null");
            this.queue.enqueueLuggage(this.dequeueDeltaMiliSeconds, luggage);
            this.LuggageCounter++;
        }
    }
}
