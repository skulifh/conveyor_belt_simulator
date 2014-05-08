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
    class CheckInCounter : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        private Boolean initialized;
        private Boolean initialized_thread;
        private IComponent nextComponent;
        public CheckInCounter(int dequeueDeltaMiliSeconds)
        {
            Contract.Requires(queue != null, "Queue must not be null");
            Contract.Requires(initialized != true, "Initialized must not be true");
            this.queue = new FIFOQueue();
            //this.enqueueBehaviour = new Source(Nullable, this.queue, )
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
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
            this.dequeueBehaviour = new Forward(this.queue, nextComponents[0]);
            this.nextComponent = nextComponents[0];
            this.initialized = true;
        }

        public List<IComponent> getSinks()
        {
            Contract.Requires(initialized != false, "Initialized must be true");
            return this.nextComponent.getSinks();
        }
    }
}
