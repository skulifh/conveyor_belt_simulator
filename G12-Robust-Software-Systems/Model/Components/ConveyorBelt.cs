using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class ConveyorBelt : IComponent
    {
        ILuggageProcessor enqueueBehaviour;
        ILuggageProcessor dequeueBehaviour;
        ILuggageQueue queue;
        Boolean initialized;
        private Boolean initialized_thread;
        public ConveyorBelt(int dequeueDeltaMiliSeconds)
        {
            this.queue = new FIFOQueue();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            if (this.initialized)
            {
                if (this.initialized_thread == false)
                {
                    Thread DequeueThread = new Thread(new ThreadStart(this.DequeueLuggage));
                    DequeueThread.Start();
                    while (!DequeueThread.IsAlive) ;
                    this.initialized_thread = true;
                }
                enqueueBehaviour.processLuggage(luggage);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void DequeueLuggage()
        {
            dequeueBehaviour.processLuggage(null);
        }

        public void setNextComponent(IComponent next, List<IComponent> sinks)
        {
            this.dequeueBehaviour = new Forward(this.queue, next);
            this.initialized = true;
        }

        public List<IComponent> getSinks()
        {
            // Intentionally not implemented.
            throw new NotImplementedException();
        }
    }
}
