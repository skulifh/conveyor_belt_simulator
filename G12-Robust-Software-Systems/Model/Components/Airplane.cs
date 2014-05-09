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
        private List<IProblem> problems;
        private Boolean initialized_thread;
        public Airplane(int dequeueDeltaMiliSeconds, List<IProblem> problems)
        {
            this.queue = new FIFOQueue();
            this.problems = problems;
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.dequeueBehaviour = new Sink(this.queue);
            this.initialized_thread = false;
        }

        public void EnqueueLuggage(LuggageBag luggage)
        {
            Contract.Requires(luggage != null, "Luggage must not be null");
            if (this.initialized_thread == false)
            {
                Thread DequeueThread = new Thread(new ThreadStart(this.DequeueLuggage));
                DequeueThread.Start();
                while (!DequeueThread.IsAlive) ;
                this.initialized_thread = true;
            }
            foreach (IProblem problem in this.problems)
            {

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
            // Intentionally not implemented, as airplane is always the last element.
            throw new NotImplementedException();
        }

        public List<IComponent> getSinks()
        {
            return new List<IComponent> { this };
        }
    }
}
