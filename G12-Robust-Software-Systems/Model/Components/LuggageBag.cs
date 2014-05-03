using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class LuggageBag
    {
        public IComponent destination {get;set;}
        public LuggageBag(IComponent destination)
        {
            this.destination = destination;
        }
    }
}
