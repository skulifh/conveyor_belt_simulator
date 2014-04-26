using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class Receive : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private int dequeueDeltaMiliSeconds;
        public Receive(ILuggageQueue queue, int dequeueDeltaMiliSeconds)
        {
            this.queue = queue;
            this.dequeueDeltaMiliSeconds = dequeueDeltaMiliSeconds;
        }

        public void processLuggage()
        {
           this.queue.enqueueLuggage(this.dequeueDeltaMiliSeconds);
        }
    }
}
