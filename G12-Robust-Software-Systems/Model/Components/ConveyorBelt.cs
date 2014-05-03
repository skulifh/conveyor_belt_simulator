using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class ConveyorBelt : IComponent
    {
        ILuggageProcessor enqueueBehaviour;
        ILuggageProcessor dequeueBehaviour;
        ILuggageQueue queue;
        Boolean initialized;
        public ConveyorBelt(int dequeueDeltaMiliSeconds)
        {
            this.queue = new FIFOQueue();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            enqueueBehaviour.processLuggage(luggage);
        }

        public void DequeueLuggage(LuggageBag luggage)
        {
            if (this.initialized)
            {
                dequeueBehaviour.processLuggage(luggage);
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }

        public void setNextComponent(IComponent next, List<IComponent> sinks)
        {
            this.dequeueBehaviour = new Forward(this.queue, next);
            this.initialized = true;
        }
    }
}
