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
            /*while(true) 
            {
                Simulation.Genpop bla = new Simulation.Genpop();


                Console.WriteLine("Testing git");
            }*/
         //   Simulation.Genpop.Runner(2);
            Console.WriteLine("Testing git");
            String bla = Simulation.Parser.validate("test.txt");
            Console.WriteLine(bla);
            System.Threading.Thread.Sleep(10000);
                
        }

    }
}
