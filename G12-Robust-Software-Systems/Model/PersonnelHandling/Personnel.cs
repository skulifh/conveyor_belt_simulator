using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.PersonnelHandling
{
    public class Personnel
    {
        private int id;
        private List<IRole> roles;
        
        public Personnel(int id, List<IRole> roles)
        {

            this.id = id;
            this.roles = roles;
        }

        public List<IRole> get_roles()
        {
            return roles;
        }

        public void add_role(IRole role){
            Contract.Requires<ArgumentOutOfRangeException>(
                role != null,
                "role cannot be null"
            );

            // ensure that "roles" doesn't have duplicates
            Contract.Ensures(Contract.ForAll(roles, r1 => !Contract.Exists(roles, r2 => r1 != r2 && r1.GetType() == r2.GetType())));
           
            roles.Add(role);
        }

        public void remove_role(IRole role)
        {
            roles.RemoveAll(r => r.GetType() == role.GetType());

            Contract.Ensures(
                roles.Count > 0,
                "Personnel must have at least one role"
            );
        }

        public Boolean HasRole(IRole role)
        {
            foreach (IRole personnel_role in this.roles)
            {
                if (role.GetType() == personnel_role.GetType()){
                    return true;
                }
            }
            return false;
        }
    }
}
