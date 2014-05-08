using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class Airplane : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        private Boolean initialized;
        private Boolean initialized_thread;
        public Airplane(int dequeueDeltaMiliSeconds)
        {
            Contract.Requires(queue != null, "Queue must not be null");
            Contract.Requires(initialized != true, "Initialized must not be true");
            this.queue = new FIFOQueue();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.dequeueBehaviour = new Sink(this.queue);
        }

        public void EnqueueLuggage(LuggageBag luggage)
        {
            Contract.Requires(initialized != false, "Initialized must be true");
            Contract.Requires(luggage != null, "Luggage must not be null");
            if (this.initialized_thread == false)
            {
                Thread DequeueThread = new Thread(new ThreadStart(this.DequeueLuggage));
                DequeueThread.Start();
                while (!DequeueThread.IsAlive) ;
                this.initialized_thread = true;
            }
            enqueueBehaviour.processLuggage(luggage);
        }

        public void DequeueLuggage()
        {
            while (true)
            {
                dequeueBehaviour.processLuggage(null);
                Thread.Sleep(10);
            }
        }

        public void setNextComponent(List<IComponent> nextComponents)
        {
            // Intentionally not implemented, as airplane is always the last element.
            throw new NotImplementedException();
        }

        public List<IComponent> getSinks()
        {
            return new List<IComponent> { this };
        }
    }
}
