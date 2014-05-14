using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    public class Source : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private List<Tuple<int, LuggageBag>> luggageAndDequeueDelta;
        public int LuggageCounter { private set; get; }
        public Source(ILuggageQueue queue, List<Tuple<int, LuggageBag>> luggageAndDequeueDelta)
        {
            Contract.Requires(luggageAndDequeueDelta != null, "List of luggage may not be null");
            Contract.Requires(luggageAndDequeueDelta.Count > 0, "List of luggage may not be empty.");
            Contract.Requires(queue != null, "queue cannot be null");
            this.LuggageCounter = 0;
            this.queue = queue;
            this.luggageAndDequeueDelta = luggageAndDequeueDelta;
        }

        public void processLuggage(LuggageBag luggage)
        {
            long now = DateTime.Now.Ticks;
            while (true){
                while (this.luggageAndDequeueDelta.Count > 0 && this.luggageAndDequeueDelta[0].Item1 + now >= DateTime.Now.Ticks)
                {
                    LuggageBag element = this.luggageAndDequeueDelta[0].Item2;
                    this.luggageAndDequeueDelta.RemoveAt(0);
                    this.queue.enqueueLuggage(0, element);
                    this.LuggageCounter++;
                }
                if (this.luggageAndDequeueDelta.Count == 0)
                {
                    break;
                }
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
