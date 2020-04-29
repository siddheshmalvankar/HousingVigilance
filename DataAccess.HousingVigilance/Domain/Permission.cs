using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public class Permission:BaseEntity
    {
        public int PermissionID { get; set; }
        public char PermissionType { get; set; }
        public string PermissionName { get; set; }
       
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
       
    }
}
