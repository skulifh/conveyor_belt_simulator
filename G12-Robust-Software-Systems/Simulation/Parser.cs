using G12_Robust_Software_Systems.Model.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Simulation
{
    class Parser
    {
        static void Main()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
            string line;
            string type;
            int mode = 0;
            List<CheckInCounter> checkins = new List<CheckInCounter>();
            List<ConveyorBelt> belts = new List<ConveyorBelt>();
            List<XRayMachine> xrays = new List<XRayMachine>();
            List<ConveyorBeltSplitter> splitters = new List<ConveyorBeltSplitter>();

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                type = line.Split(' ')[0];

                if (type.Equals("CHECKIN"))
                {
                    checkins.Add(new CheckInCounter());
                }
                else if (type.Equals("BELT"))
                {
                    belts.Add(new ConveyorBelt());
                }
                else if (type.Equals("XRAY"))
                {
                    xrays.Add(new XRayMachine());
                }
                else if (type.Equals("SPLITTER"))
                {
                    splitters.Add(new ConveyorBeltSplitter());
                }
                else if (type.Equals("ROUTING"))
                {
                    break;
                }
            }

            Console.WriteLine(checkins[0]);

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line.Equals("END"))
                {
                    break;
                }
            }

            System.Threading.Thread.Sleep(10000);
            file.Close();
        }
    }
}
