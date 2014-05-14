using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G12_Robust_Software_Systems.Model.PersonnelHandling
{
    public class XRayRole : IRole
    {
        public bool Equals(IRole role)
        {
            return role.GetType() == typeof(XRayRole);
        }
    }
}
