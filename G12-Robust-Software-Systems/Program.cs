using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems
{
    class Program
    {

        public double Divide(double number, double divisor)
        {
            Contract.Requires<ArgumentOutOfRangeException>(
                divisor != 0,
                "Divide by zero is not allowed."
                );

            return number / divisor;
        }

        static void Main(string[] args)
        {
            Program dafuq = new Program();
            double blabla = dafuq.Divide(5, 2);
            Console.WriteLine(blabla);
            System.Threading.Thread.Sleep(10000);

        }
    }
}
