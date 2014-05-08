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
        public CheckInCounter(int dequeueDeltaMiliSeconds, List<Tuple<int, LuggageBag>> luggageAndDequeueDelta, List<IProblem> problems)
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
            // intentionally not implemented.
            throw new NotImplementedException();
        }

        public void DequeueLuggage()
        {
            Thread DequeueThread = new Thread(new ThreadStart(this.DequeueWorker));
            DequeueThread.Start();
            while (!DequeueThread.IsAlive) ;
            this.initialized_thread = true;
        }

        private void DequeueWorker()
        {
            while (true)
            {
                dequeueBehaviour.processLuggage(null);
                Thread.Sleep(10);
            }
        }

        public void addNextComponent(IComponent nextComponent)
        {
            Contract.Requires(this.initialized == false, "System is already initialized");
            this.dequeueBehaviour = new Forward(this.queue, nextComponent);
            this.nextComponent = nextComponent;
            this.initialized = true;
        }

        public List<IComponent> getSinks()
        {
            Contract.Requires(initialized != false, "Initialized must be true");
            return this.nextComponent.getSinks();
        }
    }
}
