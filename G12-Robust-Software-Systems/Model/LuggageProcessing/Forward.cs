using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class Forward : ILuggageProcessor
    {
        private ILuggageQueue queue;
        private IComponent nextComponent;
        public Forward(ILuggageQueue queue, IComponent nextComponent)
        {
            this.queue = queue;
            this.nextComponent = nextComponent;
        }
        public void processLuggage()
        {
           int luggageToForward = this.queue.checkLuggageQueue();
           while (luggageToForward > 0)
           {
               this.nextComponent.EnqueueLuggage();
               luggageToForward--;
           }
        }
    }
}
