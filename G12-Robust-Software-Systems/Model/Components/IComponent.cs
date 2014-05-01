using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Components
{
    interface IComponent
    {
        void EnqueueLuggage();

        void DequeueLuggage();

        void setNextComponent(IComponent next);
    }
}
