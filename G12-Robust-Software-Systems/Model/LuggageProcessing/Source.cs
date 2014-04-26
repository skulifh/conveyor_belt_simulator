using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.LuggageProcessing
{
    class Source : ILuggageProcessor
    {
        private double distributionInput;
        public Source(double distributionInput)
        {
            this.distributionInput = distributionInput;
        }

        public void processLuggage()
        {
            throw new NotImplementedException();
        }
    }
}
