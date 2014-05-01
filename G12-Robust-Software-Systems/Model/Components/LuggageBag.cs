using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    class LuggageBag
    {
        private IComponent destination;
        public LuggageBag(IComponent destination)
        {
            this.destination = destination;
        }
    }
}
