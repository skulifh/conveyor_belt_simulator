using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    public interface ILuggageProcessor
    {
        void processLuggage(LuggageBag luggage);

        int LuggageCounter { get; }
    }
}
