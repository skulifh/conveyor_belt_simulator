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
        public Sink(ILuggageQueue queue)
        {
            this.queue = queue;
        }
        public void processLuggage()
        {
            while (true)
            {
                this.queue.checkLuggageQueue();
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
