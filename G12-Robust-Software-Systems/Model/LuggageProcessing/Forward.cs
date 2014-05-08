using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class Forward : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private IComponent nextComponent;
        public Forward(ILuggageQueue queue, IComponent nextComponent)
        {
            Contract.Requires(queue != null, "queue cannot be null");
            Contract.Requires(nextComponent != null, "nextComponent cannot be null");

            this.queue = queue;
            this.nextComponent = nextComponent;
        }
        public void processLuggage(LuggageBag luggage)
        {
           Contract.Requires(luggage != null, "luggage cannot be null");

            List<LuggageBag> luggageToForward = this.queue.checkLuggageQueue();
           while (luggageToForward.Count() > 0)
           {
               this.nextComponent.EnqueueLuggage(luggageToForward[0]);
               luggageToForward.RemoveAt(0);
           }
        }
    }
}
