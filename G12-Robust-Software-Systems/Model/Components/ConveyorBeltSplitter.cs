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
    public class ConveyorBeltSplitter : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        public Boolean initialized { get; private set; }
        public String name { get; private set; }
        private List<IComponent> sinks;
        private List<IProblem> problems;
        private Boolean initialized_thread;
        public Boolean stuck { get; private set; }
        public ConveyorBeltSplitter(int dequeueDeltaMiliSeconds, List<IProblem> problems, int id)
        {
            this.sinks = new List<IComponent>();
            this.queue = new FIFOQueue();
            this.name = "Conveyor belt splitter number: " + id.ToString();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
            this.initialized_thread = false;
            this.problems = problems;
            this.stuck = false;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            //Contract.Requires(initialized != false, "Initialized must be true");
            Contract.Requires(luggage != null, "Luggage must not be null");
            while (this.stuck) ;
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
            //Contract.Requires(this.sinks.Count < 2, "Splitter only supports two \"outputs\"");
            Contract.Requires(nextComponent != null, "next component can't be null");
            this.sinks.Add(nextComponent);
            if (this.sinks.Count == 2)
            {
                this.dequeueBehaviour = new SortingForwarder(this.queue, this.sinks);
                this.initialized = true;
            }
        }

        public List<IComponent> getSinks()
        {
            // Merge getsinks from other components.
            List<IComponent> allSinks = new List<IComponent>();
            foreach (IComponent sink in this.sinks)
            {
                allSinks.Concat(sink.getSinks());
            }
            return allSinks;
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
