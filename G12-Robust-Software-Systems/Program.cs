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
            Random random = new Random();
            while(true) 
            {
                //Parser bla = new Parser();
                //List<int> bags = Genpop.GetBags(50000, 1500);
                /*foreach (int elem in bags)
                {
                    Console.WriteLine(elem);
                }*/
                
                /*for (int i = 0; i < 20; i++)
                {
                    bool like = Genpop.Failure(50);
                    Console.WriteLine(like);
                    //int dest = Genpop.Multi(0);
                    //Console.WriteLine("skuli:" + dest);
                   //bool like = Genpop.Failure(0.5);
                   //Console.WriteLine(like);
                    //System.Threading.Thread.Sleep(20);
                }*/
                

                System.Threading.Thread.Sleep(50000);
            }
        }

    }
}
