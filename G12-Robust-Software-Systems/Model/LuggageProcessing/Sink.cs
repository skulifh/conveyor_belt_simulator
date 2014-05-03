using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class Sink : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private int counter;
        public Sink(ILuggageQueue queue)
        {
            this.queue = queue;
            this.counter = 0;
        }
        public void processLuggage(LuggageBag luggage)
        {
            List<LuggageBag> receivedLuggage = this.queue.checkLuggageQueue();
            counter += receivedLuggage.Count();
        }
    }
}
