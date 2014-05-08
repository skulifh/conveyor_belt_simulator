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
    class ConveyorBeltSplitter : IComponent
    {
        private ILuggageProcessor enqueueBehaviour;
        private ILuggageProcessor dequeueBehaviour;
        private ILuggageQueue queue;
        private Boolean initialized;
        private List<IComponent> sinks;
        private Boolean initialized_thread;
        public ConveyorBeltSplitter(int dequeueDeltaMiliSeconds, List<IProblem> problems)
        {
            Contract.Requires(queue != null, "Queue must not be null");
            Contract.Requires(initialized != true, "Initialized must not be true");
            this.sinks = new List<IComponent>();
            this.queue = new FIFOQueue();
            this.enqueueBehaviour = new Receive(this.queue, dequeueDeltaMiliSeconds);
            this.initialized = false;
            this.initialized_thread = false;
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

        public void addNextComponent(IComponent nextComponent)
        {
            Contract.Requires(this.initialized == false, "System is already initialized");
            Contract.Requires(this.sinks.Count < 2, "Splitter only supports two \"outputs\"");
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
    }
}
