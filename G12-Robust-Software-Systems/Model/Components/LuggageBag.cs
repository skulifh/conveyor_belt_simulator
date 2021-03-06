﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    public class LuggageBag
    {
        public IComponent destination {get; private set;}
        public LuggageBag(IComponent destination)
        {
            Contract.Requires(destination != null, "Destination can't be null");
            this.destination = destination;
        }
    }
}
