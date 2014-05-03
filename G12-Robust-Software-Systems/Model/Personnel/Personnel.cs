using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.Personnel
{
    class Personnel
    {
        private int id;
        private List<IRole> roles;
        
        public Personnel(int id = -1, List<IRole> roles = null)
        {
            this.id = id;
            this.roles = roles;
        }

        public List<IRole> get_roles()
        {
            return roles;
        }

        public void add_role(IRole role){
            roles.Add(role);
        }

        public void remove_role(IRole role)
        {
            roles.RemoveAll(r => r.GetType() == role.GetType());
        }
    }
}
