using G12_Robust_Software_Systems.Model;
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
        private double[,] routingMatrix;
        List<CheckInCounter> checkins = new List<CheckInCounter>();
        public Parser()
        {
            string path = "c:\\test.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            string val = validate(path);
            Console.WriteLine(val);

            string line;
            string[] lineSplit;
            string type;
            string typeNext;
            string comp;
            string compNext;
            int ind;
            int indNext;
            int time = 0;

            bool cont = true;
            
            List<ConveyorBelt> belts = new List<ConveyorBelt>();
            List<XRayMachine> xrays = new List<XRayMachine>();
            List<ConveyorBeltSplitter> splitters = new List<ConveyorBeltSplitter>();

            while (((line = file.ReadLine()) != null) && (cont))
            {
                lineSplit = line.Split(' ');

                if (lineSplit.Length == 3)
                    time = Int32.Parse(lineSplit[2]);

                type = lineSplit[0];
                Console.WriteLine(type);

                switch (type)
                {
                    case "CHECKIN":
                        //checkins.Add(new CheckInCounter(time, new List<IProblem> { new Stuck(5), new StopWorking(5) }));
                        this.addCheckin(time);
                        break;

                    case "BELT":
                        belts.Add(new ConveyorBelt(time));
                        break;

                    case "XRAY":
                        xrays.Add(new XRayMachine(time, new List<IProblem> {new Stuck(5), new StopWorking(5)}));
                        break;

                    case "SPLITTER":
                        splitters.Add(new ConveyorBeltSplitter(time));
                        break;

                    case "ROUTING":
                        cont = false;
                        break;
                }
            }
            Console.WriteLine(belts[0]);
            cont = true;

            while (((line = file.ReadLine()) != null) && cont)
            {
                lineSplit = line.Split(',');

                if (line.Length == 0)
                    continue;
                else if (line.Equals("END"))
                    break;

                type = lineSplit[0];
                typeNext = lineSplit[1];

                comp = type.Split('_')[0];
                compNext = typeNext.Split('_')[0];

                ind = Int32.Parse(type.Split('_')[1]);
                indNext = Int32.Parse(typeNext.Split('_')[1]);

                Console.WriteLine(type);

                switch (comp)
                {
                    case "check":
                        switch (compNext)
                        {
                            case "belt":
                                checkins[ind].setNextComponent(new List<IComponent> {belts[indNext]});
                                break;
                            case "x":
                                checkins[ind].setNextComponent(new List<IComponent> {xrays[indNext]});
                                break;
                            case "splitter":
                                checkins[ind].setNextComponent(new List<IComponent> {splitters[indNext]});
                                break;
                        }
                        break;

                    case "belt":
                        switch (compNext)
                        {
                            case "belt":
                                belts[ind].setNextComponent(new List<IComponent> {belts[indNext]});
                                break;
                            case "x":
                                belts[ind].setNextComponent(new List<IComponent> {xrays[indNext]});
                                break;
                            case "splitter":
                                belts[ind].setNextComponent(new List<IComponent> {splitters[indNext]});
                                break;
                        }
                        break;

                    case "x":
                        switch (compNext)
                        {
                            case "belt":
                                xrays[ind].setNextComponent(new List<IComponent> {belts[indNext]});
                                break;
                            case "x":
                                xrays[ind].setNextComponent(new List<IComponent> {xrays[indNext]});
                                break;
                            case "splitter":
                                xrays[ind].setNextComponent(new List<IComponent> {splitters[indNext]});
                                break;
                        }
                        break;

                    /*case "splitter":
                        switch (compNext)
                        {
                            case "belt":
                                splitters[ind].setNextComponent(belts[indNext]);
                                break;
                            case "x":
                                splitters[ind].setNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                splitters[ind].setNextComponent(splitters[indNext]);
                                break;
                        }
                        break;*/

                    case "END":
                        cont = false;
                        break;
                }
            }

            System.Threading.Thread.Sleep(10000);
            file.Close();
        }
        /*static void Main()
        {
            
        }*/

        public void addCheckin(int time)
        {
            Genpop gen = new Genpop();

        }

        public static string validate(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line;
            string results = "ok!";
            string index0;
            string index2;
            string[] lineSplit;
            int number;
            int counter = 1;

            while ((line = file.ReadLine()) != null)
            {
                lineSplit = line.Split(' ');
                if ((line.Equals("INIT")) || (line.Trim().Length == 0))
                {
                    counter += 1;
                    continue;
                }
                else if (lineSplit.Length < 3)
                {
                    results = "Initialisation commands need to have 3 arguments (line: " + counter + ")";
                    break;
                }
                else if (line.Equals("ROUTING"))
                    break;
                else
                {
                    index0 = lineSplit[0];
                    index2 = lineSplit[2];
                    if (!((index0.Equals("CHECKIN")) || (index0.Equals("BELT")) || (index0.Equals("XRAY")) || (index0.Equals("SPLITTER")) || (index0.Equals("SORT"))))
                    {
                        results = "Components need to be either of type CHECKIN, BELT, XRAY, SPLITTER or SORT (line: " + counter + ")";
                        break;
                    }
                    else if (!int.TryParse(index2, out number))
                    {
                        results = "Third argument of each initialisation needs to be a number (time in milliseconds) (line: " + counter + ")";
                        break;
                    }

                }
                counter += 1;
            }

            while ((line = file.ReadLine()) != null)
            {
                lineSplit = line.Split(' ');
                if (line.Trim().Length == 0)
                {
                    counter += 1;
                    continue;
                }
            }
            return results;
        }


    }
}
