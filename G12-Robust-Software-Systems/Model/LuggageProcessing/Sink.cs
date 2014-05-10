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
        private int counter;
        public Sink(ILuggageQueue queue)
        {
            Contract.Requires(queue != null, "queue cannot be null");

            this.queue = queue;
            this.counter = 0;
        }
        public void processLuggage(LuggageBag luggage)
        {
            Contract.Requires(luggage != null, "luggage cannot be null");

            List<LuggageBag> receivedLuggage = this.queue.checkLuggageQueue();
            counter += receivedLuggage.Count();
        }
    }
}
