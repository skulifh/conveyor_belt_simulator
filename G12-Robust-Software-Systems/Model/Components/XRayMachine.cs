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
    class XRayMachine : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        private Boolean initialized;
        private Boolean initialized_thread;
        private List<IProblem> problems;
        private IComponent nextComponent;
        public XRayMachine(int dequeueDeltaMiliSeconds, List<IProblem> problems)
        {
            this.queue = new FIFOQueue();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
            this.initialized_thread = false;
            this.problems = problems;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            //Contract.Requires(initialized != false, "Initialized must be true");
            Contract.Requires(luggage != null, "Luggage must not be null");
            if (this.initialized_thread == false)
            {
                Thread DequeueThread = new Thread(new ThreadStart(this.DequeueLuggage));
                DequeueThread.Start();
                while (!DequeueThread.IsAlive);
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

        public void addNextComponent(IComponent nextComponent)
        {
            Contract.Requires(this.initialized == false, "System is already initialized");
            this.dequeueBehaviour = new Forward(this.queue, nextComponent);
            this.nextComponent = nextComponent;
            this.initialized = true;
        }

        public List<IComponent> getSinks()
        {
            //Contract.Requires(initialized != false, "Initialized must be true");
            return this.nextComponent.getSinks();
        }
    }
}
