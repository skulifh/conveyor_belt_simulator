using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Simulation;
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
            Program program = new Program();
            Parser parser = new Parser();

            List<IComponent> list = parser.getLists();
            List<CheckInCounter> checkinsList = parser.getCheckins();

            foreach (CheckInCounter checkin in checkinsList)
            {
                checkin.EnqueueLuggage(null);
            }

            while (true) {
                program.iPrinter(list);
            }
        }

        public void iPrinter(List<IComponent> list)
        {
            string text;
            foreach (IComponent component in list)
            {
                text = component.name + "\t" + "bags: " + component.Count().ToString();
                Console.Clear();
                Console.WriteLine(text);
            }
        }
            

    }
}
