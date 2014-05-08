using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class FIFOQueue : ILuggageQueue
    {
        private Queue<Tuple<long, LuggageBag>> queue;

        public FIFOQueue()
        {
            this.queue = new Queue<Tuple<long, LuggageBag>>();
        }
        public void enqueueLuggage(int dequeueDeltaMiliSeconds, LuggageBag luggage)
        {
            Contract.Requires(dequeueDeltaMiliSeconds >= 0, "dequeueDeltaMiliSeconds cannot be less than zero");
            Contract.Requires(luggage != null, "luggage cannot be null");

            Tuple<long, LuggageBag> luggageTuple = new Tuple<long, LuggageBag>(DateTime.Now.Ticks + dequeueDeltaMiliSeconds * 1000, luggage);
            this.queue.Enqueue(luggageTuple);
        }

        public List<LuggageBag> checkLuggageQueue()
        {
            List<LuggageBag> departing_luggage = new List<LuggageBag>();
            if (this.queue.Count() > 0)
            {
                long now = DateTime.Now.Ticks;
                // While there is elements in the queue, and the elements
                // have been in the queue long enough for them to be dequeued.
                while (this.queue.Count() > 0 && this.queue.ElementAt<Tuple<long, LuggageBag>>(0).Item1 <= now)
                {
                    // Increment counter and remove element from queue.
                    departing_luggage.Add(this.queue.Dequeue().Item2);
                }
            }
            return departing_luggage;
        }
    }
}
