﻿using System;
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
            /*while(true) 
            {
                Simulation.Genpop bla = new Simulation.Genpop();


                Console.WriteLine("Testing git");
            }*/
         //   Simulation.Genpop.Runner(2);
            String result = Simulation.Parser.validate("../../Files/test.txt");
            Console.WriteLine(result);
            System.Threading.Thread.Sleep(10000);
                
        }

    }
}
