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
    public class CheckInCounter : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        public Boolean initialized { get; private set; }
        public String name { get; private set; }
        private Boolean initialized_thread;
        private List<IProblem> problems;
        private IComponent nextComponent;
        public CheckInCounter(List<Tuple<int, LuggageBag>> luggageAndDequeueDelta, List<IProblem> problems, int id)
        {
            this.problems = problems;
            this.name = "Check in counter number: " + id.ToString();
            this.queue = new FIFOQueue();
            this.enqueueBehaviour = new Source(this.queue, luggageAndDequeueDelta);
            this.initialized = false;
            this.initialized_thread = false;
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
            //Contract.Requires(this.initialized == false, "System is already initialized");
            Contract.Requires(nextComponent != null, "next component can't be null");
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
