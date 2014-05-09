using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.PersonnelHandling
{
    class Personnel_Test
    {
        public static void Main(string[] args)
        {
            List<IRole> roles = new List<IRole>();

            Console.WriteLine("Add LoaderRole");
            roles.Add(new LoaderRole());

            Console.WriteLine("Add StuckLuggageRole");
            roles.Add(new StuckLuggageRole());

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

            Console.WriteLine("Add XRayRole");
            p.add_role(new XRayRole());

            Console.WriteLine("Roles:");
            foreach (IRole role in p.get_roles())
            {
                Console.WriteLine(role);
            }


            Console.ReadLine();
        }
    }
}
