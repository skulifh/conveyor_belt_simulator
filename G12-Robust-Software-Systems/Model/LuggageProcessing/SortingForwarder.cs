using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    public class SortingForwarder : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private List<IComponent> nextComponents;
        public int LuggageCounter { private set; get; }
        public SortingForwarder(ILuggageQueue queue, List<IComponent> nextComponents)
        {
            Contract.Requires(queue != null, "queue cannot be null");
            Contract.Requires(nextComponents != null, "nextComponents cannot be null");

            this.LuggageCounter = 0;
            this.queue = queue;
            this.nextComponents = nextComponents;
        }
        public void processLuggage(LuggageBag luggage)
        {
            List<LuggageBag> luggageToForward = this.queue.checkLuggageQueue();
            while (luggageToForward.Count() > 0)
            {
                LuggageBag bag = luggageToForward[0];
                luggageToForward.RemoveAt(0);
                foreach (IComponent nextComponent in nextComponents){
                    try
                    {
                        List<IComponent> sinks = nextComponent.getSinks().FindAll(x => x.Equals(bag.destination));
                        int min_luggage_in_sink = -1;
                        IComponent min_sink = null;
                        foreach (IComponent sink in sinks)
                        {
                            if (min_sink == null || sink.Count() < min_luggage_in_sink)
                            {
                                min_sink = sink;
                                min_luggage_in_sink = sink.Count();
                            }
                        }
                        min_sink.EnqueueLuggage(bag);
                        this.LuggageCounter++;
                        break;
                    }
                    catch (ArgumentNullException)
                    {
                        // Do nothing
                    }
                }
            }
        }
    }
}
