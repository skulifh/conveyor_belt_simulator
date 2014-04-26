using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class FIFOQueue : ILuggageQueue
    {
        private List<long> queue;

        public FIFOQueue()
        {
            this.queue = new List<long>();
        }
        public void enqueueLuggage()
        {
            this.queue.Add(DateTime.Now.Ticks);
        }

        public bool checkLuggageQueue()
        {
            throw new NotImplementedException();
        }
    }
}
