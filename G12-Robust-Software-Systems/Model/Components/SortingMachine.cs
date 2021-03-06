﻿using G12_Robust_Software_Systems.Model.LuggageProcessing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    public class SortingMachine : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        public Boolean initialized { get; private set; }
        public String name { get; private set; }
        private List<IComponent> sinks;
        private Boolean initialized_thread;
        private List<IProblem> problems;
        private List<IComponent> allSinks;
        public Boolean stuck { get; private set; }
        public SortingMachine(int dequeueDeltaMiliSeconds, List<IProblem> problems, int id)
        {
            this.queue = new FIFOQueue();
            this.sinks = new List<IComponent>();
            this.name = "Sorting m. number: " + id.ToString();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
            this.problems = problems;
            this.stuck = false;
            this.allSinks = null;
        }
        public void EnqueueLuggage(LuggageBag luggage)
        {
            //Contract.Requires(this.initialized != false, "Initialized must be true");
            Contract.Requires(luggage != null, "Luggage must not be null");
            //Contract.Requires(this.sinks.Count > 2, "Sorting machine needs at least three \"outputs\"");
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
            Contract.Requires(nextComponent != null, "next component can't be null");
            this.sinks.Add(nextComponent);
        }

        public void SetInitialized()
        {
            if (this.sinks.Count >= 2)
            {
                this.dequeueBehaviour = new SortingForwarder(this.queue, this.sinks);
            }
        }

        public List<IComponent> getSinks()
        {
            if (this.allSinks == null)
            {
                // Merge getsinks from other components.
                List<IComponent> allSinks = new List<IComponent>();
                foreach (IComponent sink in this.sinks)
                {
                    allSinks.AddRange(sink.getSinks());
                }
                this.allSinks = allSinks;
                return allSinks;
            }
            return this.allSinks;
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
