using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.PersonnelHandling
{
    class PersonnelController
    {
        List<Personnel> personnel;
        public PersonnelController(List<Personnel> personnel)
        {
            this.personnel = personnel;
        }

        public Personnel acquirePersonWithRole(IRole role)
        {
            // Searches all personnel to find a person with role.
            // NOTE: is potentially not able to find one, if role contains uses equals and that does not match simply by type.
            // Might have to override Equals method of roles.
            try
            {
                Personnel person = this.personnel.Find(x => x.get_roles().Contains(role));
                this.personnel.Remove(person);
                return person;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public void returnPerson(Personnel person)
        {
            this.personnel.Add(person);
        }
    }
}
