using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public void iPrinter(List<IComponent> list)
        {
            string text;
            foreach (IComponent component in list)
            {
                text = component.name + "\t" + "bags: ";
            }
        }

    }
}
