using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    public class FIFOQueue : ILuggageQueue
    {
        private ConcurrentQueue<Tuple<long, LuggageBag>> queue;

        public FIFOQueue()
        {
            this.queue = new ConcurrentQueue<Tuple<long, LuggageBag>>();
        }
        public void enqueueLuggage(int dequeueDeltaMiliSeconds, LuggageBag luggage)
        {
            Contract.Requires(dequeueDeltaMiliSeconds >= 0, "dequeueDeltaMiliSeconds cannot be less than zero");
            Contract.Requires(luggage != null, "luggage cannot be null");

            Tuple<long, LuggageBag> luggageTuple = new Tuple<long, LuggageBag>(DateTime.Now.Ticks + dequeueDeltaMiliSeconds * 10000, luggage);
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
                Tuple<long, LuggageBag> firstElem;
                Boolean peek_successful = this.queue.TryPeek(out firstElem);
                while (peek_successful && firstElem.Item1 <= now)
                {
                    // Increment counter and remove element from queue.
                    Tuple<long, LuggageBag> dequeuedItem;
                    Boolean dequeuedSomething = this.queue.TryDequeue(out dequeuedItem);
                    if (dequeuedSomething)
                    {
                        departing_luggage.Add(dequeuedItem.Item2);
                    }
                    peek_successful = this.queue.TryPeek(out firstElem);
                }
            }
            return departing_luggage;
        }

        public int Count()
        {
            return this.queue.Count;
        }
    }
}
