using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Personnel
{
    class Personnel_Test
    {
        public static void Main(string[] args)
        {
            List<IRole> roles = new List<IRole>();

            roles.Add(new LoaderRole());
            Console.WriteLine("Add LoaderRole");
            roles.Add(new StuckLuggageRole());
            Console.WriteLine("Add StuckLuggageRole");

            Personnel p = new Personnel(1,roles);

            Console.WriteLine("Roles:");
            foreach(IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }

            p.remove_role(new StuckLuggageRole());
            Console.WriteLine("Removed StuckLuggageRole");

            Console.WriteLine("Roles:");
            foreach(IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }

            p.add_role(new XRayRole());
            Console.WriteLine("Add XRayRole");

            Console.WriteLine("Roles:");
            foreach (IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }


            Console.ReadLine();
        }
    }
}
