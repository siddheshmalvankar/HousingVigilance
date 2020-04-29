using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain
{
    public class Role:BaseEntity
    {
        public Role()
        {
            this.Permissions = new List<Permission>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }     
        public virtual User User { get; set; }
       

    }
}
