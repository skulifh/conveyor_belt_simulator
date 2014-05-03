using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class CheckInCounter : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        private Boolean initialized;
        public CheckInCounter(int dequeueDeltaMiliSeconds)
        {
            this.queue = new FIFOQueue();
            //this.enqueueBehaviour = new Source(Nullable, this.queue, )
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            if (this.initialized)
            {
                enqueueBehaviour.processLuggage(luggage);
            }
            else
            {
                throw new NotImplementedException();
            }
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
