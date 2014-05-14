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
    public class Truck : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        public Boolean initialized { get; private set; }
        public String name { get; private set; }
        private Boolean initialized_thread;
        private IComponent nextComponent;
        private List<IProblem> problems;
        private Boolean stuck;
        public Truck(int dequeueDeltaMiliSeconds, List<IProblem> problems, int id)
        {
            this.queue = new FIFOQueue();
            this.name = "Truck number: " + id.ToString();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
            this.problems = problems;
            this.stuck = false;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            //Contract.Requires(initialized != false, "Initialized must be true");
            Contract.Requires(luggage != null, "Luggage must not be null");
            while (!this.stuck) ;
            if (this.initialized_thread == false)
            {
                Thread DequeueThread = new Thread(new ThreadStart(this.DequeueLuggage));
                DequeueThread.Start();
                while (!DequeueThread.IsAlive) ;
                this.initialized_thread = true;
            }
            foreach (IProblem problem in this.problems)
            {
                if (problem.Fail())
                {
                    this.stuck = true;
                    problem.HandleProblem();
                    this.stuck = false;
                }
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

        public int Count()
        {
            return this.queue.Count();
        }

        public Tuple<int, int> InAndOutCounters()
        {
            return new Tuple<int, int>(this.enqueueBehaviour.LuggageCounter, this.dequeueBehaviour.LuggageCounter);
        }
    }
}
