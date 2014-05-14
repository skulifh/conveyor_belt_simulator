using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    public interface IComponent
    {
       void EnqueueLuggage(LuggageBag luggage);

        void DequeueLuggage();

        void addNextComponent(IComponent nextComponent);

        List<IComponent> getSinks();

        string name { get; }
        Boolean initialized { get; }

        int Count();

        Tuple<int, int> InAndOutCounters();
    }
}
