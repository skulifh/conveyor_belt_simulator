using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    public class Sink : ILuggageProcessor
    {
        private ILuggageQueue queue;
        public int LuggageCounter { private set; get; }
        public Sink(ILuggageQueue queue)
        {
            Contract.Requires(queue != null, "queue cannot be null");

            this.LuggageCounter = 0;
            this.queue = queue;
        }
        public void processLuggage(LuggageBag luggage)
        {
            Contract.Requires(luggage != null, "luggage cannot be null");

            List<LuggageBag> receivedLuggage = this.queue.checkLuggageQueue();
            this.LuggageCounter += receivedLuggage.Count();
        }
    }
}
