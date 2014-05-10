using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    interface IComponent
    {
        public void EnqueueLuggage(LuggageBag luggage);

        public void DequeueLuggage();

        public void addNextComponent(IComponent nextComponent);

        public List<IComponent> getSinks();
    }
}
