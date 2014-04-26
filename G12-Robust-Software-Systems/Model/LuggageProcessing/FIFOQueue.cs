using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class FIFOQueue : ILuggageQueue
    {
        private Queue<long> queue;

        public FIFOQueue()
        {
            this.queue = new Queue<long>();
        }
        public void enqueueLuggage(int dequeueDeltaMiliSeconds)
        {
            this.queue.Enqueue(DateTime.Now.Ticks + dequeueDeltaMiliSeconds*1000);
        }

        public int checkLuggageQueue()
        {
            if (this.queue.Count() < 1)
            {
                return 0;
            }
            long now = DateTime.Now.Ticks;
            int luggage_departing_count = 0;
            // While there is elements in the queue, and the elements
            // have been in the queue long enough for them to be dequeued.
            while (this.queue.Count() > 0 && this.queue.ElementAt<long>(0) > now)
            {
                // Increment counter and remove element from queue.
                luggage_departing_count++;
                this.queue.Dequeue();
            }
            return luggage_departing_count;
        }
    }
}
