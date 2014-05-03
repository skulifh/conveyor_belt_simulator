using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class SortingMachine : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        private Boolean initialized;
        private List<IComponent> sinks;
        private Boolean initialized_thread;
        public SortingMachine(int dequeueDeltaMiliSeconds)
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
            this.sinks = sinks;
            this.dequeueBehaviour = new SortingForwarder(this.queue, sinks);
            this.initialized = true;
        }

        public List<IComponent> getSinks()
        {
            return this.sinks;
        }
    }
}
