using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    interface IComponent
    {
        void EnqueueLuggage(LuggageBag luggage);

        void DequeueLuggage();

        void setNextComponent(List<IComponent> nextComponents);

        List<IComponent> getSinks();
    }
}
