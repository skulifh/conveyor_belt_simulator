﻿using G12_Robust_Software_Systems.Model.Components;
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
            /*List<int> bags = Genpop.GetBags(200, 30);
            foreach (int bag in bags)
            {
                Console.WriteLine(bag);
            }
            System.Threading.Thread.Sleep(10000);*/
            Console.WindowHeight = 57;
            Console.WindowWidth = 120;

            Console.WriteLine(" 88888b   d888b  888b  88 8P 888888    88888b    888     888b  88 88  d888b 88");
            Console.WriteLine(" 88   88 88   88 88`8b 88      88      88   88  88 88    88`8b 88 88 88   ` 88");
            Console.WriteLine(" 88   88 88   88 88 88 88      88      88888P  88   88   88 88 88 88 88     88");
            Console.WriteLine(" 88   88 88   88 88 `8b88      88      88     d8888888b  88 `8b88 88 88   , \"\"");
            Console.WriteLine(" 88888P   `888P  88  `888      88      88     88     `8b 88  `888 88  `888P 88\n\n");


            String finalPathTest;
            String finalPathProb;
            
            Console.WriteLine("Enter path for the 'system.txt' and 'scenario.txt' files (e.g. C:/Files/) or press Enter for the default path");
            while (true)
            {
                string path = Console.ReadLine();

                if (path.Equals(""))
                {
                    path = "../../../Files/";
                }

                finalPathTest = path + "system.txt";
                finalPathProb = path + "scenario.txt";

                if (!System.IO.File.Exists(finalPathTest))
                {
                    Console.WriteLine("system.txt does not exist in the specified path");
                    continue;
                }

                else if (!System.IO.File.Exists(finalPathProb))
                {
                    Console.WriteLine("scenario.txt does not exist in the specified path");
                    continue;
                }
                else
                {
                    Console.WriteLine("Path is OK!");
                    break;
                }
            }

            String result = Initiator.validate(finalPathTest, finalPathProb);
            Console.WriteLine(result);

            Console.WriteLine("Initializing...");

            Program program = new Program();
            Initiator parser = new Initiator(finalPathTest, finalPathProb);

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
                program.iPrinter(list);
                System.Threading.Thread.Sleep(100);
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
                text = component.name + "\t\t" + "Bags: " + component.Count().ToString() + "  \t\tIn: " + 
                    tuple.Item1 + "\t\tOut: " + tuple.Item2 + "\t\tStuck: " + component.stuck;
                Console.WriteLine(text);
            }
        }
            

    }
}
