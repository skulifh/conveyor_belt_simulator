using G12_Robust_Software_Systems.Model;
using G12_Robust_Software_Systems.Model.Components;
using G12_Robust_Software_Systems.Model.PersonnelHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Simulation
{
    class Parser
    {
        //private double[,] routingMatrix;
        List<CheckInCounter> checkins = new List<CheckInCounter>();
        List<Airplane> airplanes = new List<Airplane>();
        List<ConveyorBelt> belts = new List<ConveyorBelt>();
        List<XRayMachine> xrays = new List<XRayMachine>();
        List<ConveyorBeltSplitter> splitters = new List<ConveyorBeltSplitter>();
        List<Truck> trucks = new List<Truck>();
        List<SortingMachine> sortingmachines = new List<SortingMachine>();
        
        public Parser()
        {
            List<IRole> roles = new List<IRole> { new StuckLuggageRole(), new XRayRole(), new LoaderRole() };

            List<Personnel> personnel = new List<Personnel> { new Personnel(0, roles) };
            string path = "C:\\Users\\Lenovo\\Documents\\test.txt";
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
                        this.addCheckin(time, checkins.Count(), personnel);
                        break;

                    case "BELT":
                        belts.Add(new ConveyorBelt(time, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));
                        break;

                    case "XRAY":
                        xrays.Add(new XRayMachine(time, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));
                        break;

                    case "SPLITTER":
                        splitters.Add(new ConveyorBeltSplitter(time, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));
                        break;

                    case "AIRPLANE":
                        airplanes.Add(new Airplane(time, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));
                        break;

                    case "TRUCK":
                        trucks.Add(new Truck(time, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));
                        break;

                    case "SORTINGMACHINE":
                        sortingmachines.Add(new SortingMachine(time, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));
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
                                checkins[ind].addNextComponent(belts[indNext]);
                                break;
                            case "x":
                                checkins[ind].addNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                checkins[ind].addNextComponent(splitters[indNext]);
                                break;
                            case "plane":
                                checkins[ind].addNextComponent(airplanes[indNext]);
                                break;
                            case "truck":
                                checkins[ind].addNextComponent(trucks[indNext]);
                                break;
                            case "sort":
                                checkins[ind].addNextComponent(sortingmachines[indNext]);
                                break;
                        }
                        break;

                    case "belt":
                        switch (compNext)
                        {
                            case "belt":
                                belts[ind].addNextComponent(belts[indNext]);
                                break;
                            case "x":
                                belts[ind].addNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                belts[ind].addNextComponent(splitters[indNext]);
                                break;
                            case "plane":
                                belts[ind].addNextComponent(airplanes[indNext]);
                                break;
                            case "truck":
                                belts[ind].addNextComponent(trucks[indNext]);
                                break;
                            case "sort":
                                belts[ind].addNextComponent(sortingmachines[indNext]);
                                break;
                        }
                        break;

                    case "x":
                        switch (compNext)
                        {
                            case "belt":
                                xrays[ind].addNextComponent(belts[indNext]);
                                break;
                            case "x":
                                xrays[ind].addNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                xrays[ind].addNextComponent(splitters[indNext]);
                                break;
                            case "plane":
                                xrays[ind].addNextComponent(airplanes[indNext]);
                                break;
                            case "truck":
                                xrays[ind].addNextComponent(trucks[indNext]);
                                break;
                            case "sort":
                                xrays[ind].addNextComponent(sortingmachines[indNext]);
                                break;
                        }
                        break;

                    case "splitter":
                        switch (compNext)
                        {
                            case "belt":
                                splitters[ind].addNextComponent(belts[indNext]);
                                break;
                            case "x":
                                splitters[ind].addNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                splitters[ind].addNextComponent(splitters[indNext]);
                                break;
                            case "plane":
                                splitters[ind].addNextComponent(airplanes[indNext]);
                                break;
                            case "truck":
                                splitters[ind].addNextComponent(trucks[indNext]);
                                break;
                            case "sort":
                                splitters[ind].addNextComponent(sortingmachines[indNext]);
                                break;
                        }
                        break;

                    case "truck":
                        switch (compNext)
                        {
                            case "belt":
                                trucks[ind].addNextComponent(belts[indNext]);
                                break;
                            case "x":
                                trucks[ind].addNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                trucks[ind].addNextComponent(splitters[indNext]);
                                break;
                            case "plane":
                                trucks[ind].addNextComponent(airplanes[indNext]);
                                break;
                            case "truck":
                                trucks[ind].addNextComponent(trucks[indNext]);
                                break;
                            case "sort":
                                trucks[ind].addNextComponent(sortingmachines[indNext]);
                                break;
                        }
                        break;

                    case "sort":
                        switch (compNext)
                        {
                            case "belt":
                                sortingmachines[ind].addNextComponent(belts[indNext]);
                                break;
                            case "x":
                                sortingmachines[ind].addNextComponent(xrays[indNext]);
                                break;
                            case "splitter":
                                sortingmachines[ind].addNextComponent(splitters[indNext]);
                                break;
                            case "plane":
                                sortingmachines[ind].addNextComponent(airplanes[indNext]);
                                break;
                            case "truck":
                                sortingmachines[ind].addNextComponent(trucks[indNext]);
                                break;
                            case "sort":
                                sortingmachines[ind].addNextComponent(sortingmachines[indNext]);
                                break;
                        }
                        break;

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

        public void addCheckin(int time, int index, List<Personnel> personnel)
        {
            Genpop gen = new Genpop();
            List<Tuple<int, LuggageBag>> luggageAndDequeueDelta = new List<Tuple<int, LuggageBag>>();
            List<int> bags = Genpop.GetBags(200, 30);
            int dest;

            foreach (int elem in bags)
            {
                dest = Genpop.Multi(index);
                luggageAndDequeueDelta.Add(new Tuple<int, LuggageBag>(time, new LuggageBag(airplanes[dest])));
                Console.WriteLine(dest);
                //System.Threading.Thread.Sleep(1000);
            }
            
            checkins.Add(new CheckInCounter(time, luggageAndDequeueDelta, new List<IProblem> { new Stuck(5, new PersonnelController(personnel)), new StopWorking(5) }));

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
                else if (line.Equals("ROUTING"))
                    break;
                else if (lineSplit.Length < 3)
                {
                    results = "Initialisation commands need to have 3 arguments (line: " + counter + ")";
                    break;
                }
                else
                {
                    index0 = lineSplit[0];
                    index2 = lineSplit[2];
                    if (!((index0.Equals("CHECKIN")) || (index0.Equals("BELT")) || (index0.Equals("TRUCK")) || (index0.Equals("SORTINGMACHINE")) || (index0.Equals("AIRPLANE")) || (index0.Equals("XRAY")) || (index0.Equals("SPLITTER")) || (index0.Equals("SORT"))))
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
