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
            Console.WriteLine(" 88888b   d888b  888b  88 8P 888888    88888b    888     888b  88 88  d888b 88");
            Console.WriteLine(" 88   88 88   88 88`8b 88      88      88   88  88 88    88`8b 88 88 88   ` 88");
            Console.WriteLine(" 88   88 88   88 88 88 88      88      88888P  88   88   88 88 88 88 88     88");
            Console.WriteLine(" 88   88 88   88 88 `8b88      88      88     d8888888b  88 `8b88 88 88   , \"\"");
            Console.WriteLine(" 88888P   `888P  88  `888      88      88     88     `8b 88  `888 88  `888P 88\n\n");
            
            Console.WriteLine("Initializing...");

            Program program = new Program();
            Parser parser = new Parser();

            Console.WriteLine("Initialization finished");

            List<IComponent> list = parser.getLists();
            List<CheckInCounter> checkinsList = parser.getCheckins();

            Console.WriteLine("Checkins enqueing...");

            foreach (CheckInCounter checkin in checkinsList)
            {
                checkin.EnqueueLuggage(null);
            }

            Console.WriteLine("Checkins enqueing finished, starting with rest");

            while (true) {
                //program.iPrinter(list);
                System.Threading.Thread.Sleep(500);
            }
        }

        public void iPrinter(List<IComponent> list)
        {
            string text;
            Console.Clear();

            Console.WriteLine(" 88888b   d888b  888b  88 8P 888888    88888b    888     888b  88 88  d888b 88");
            Console.WriteLine(" 88   88 88   88 88`8b 88      88      88   88  88 88    88`8b 88 88 88   ` 88");
            Console.WriteLine(" 88   88 88   88 88 88 88      88      88888P  88   88   88 88 88 88 88     88");
            Console.WriteLine(" 88   88 88   88 88 `8b88      88      88     d8888888b  88 `8b88 88 88   , \"\"");
            Console.WriteLine(" 88888P   `888P  88  `888      88      88     88     `8b 88  `888 88  `888P 88\n\n");

            Console.WriteLine("Initializing...");
            Console.WriteLine("Initialization finished");
            Console.WriteLine("Checkins enqueing...");
            Console.WriteLine("Checkins enqueing finished, starting with rest\n");
            Console.WriteLine("-----------------------------------------------\n");

            foreach (IComponent component in list)
            {
                Tuple<int,int> tuple = component.InAndOutCounters();
                text = component.name + "\t\t" + "Bags: " + component.Count().ToString() + "\tIn: " + tuple.Item1 + "\tOut: " + tuple.Item2;
                Console.WriteLine(text);
            }
        }
            

    }
}
