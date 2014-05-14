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
            Console.WriteLine("Initializing...");

            Program program = new Program();
            Parser parser = new Parser();

            Console.WriteLine("Initialization finished");

            List<IComponent> list = parser.getLists();
            List<CheckInCounter> checkinsList = parser.getCheckins();

            Console.WriteLine("Checkins enqueing...");

            foreach (CheckInCounter checkin in checkinsList)
            {
                Console.WriteLine(checkin.name);
                checkin.EnqueueLuggage(null);
            }

            Console.WriteLine("Checkins enqueing finished, starting with rest");

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
