using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain
{
    public class UserLogin:BaseEntity
    {
        public int UserLoginID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public virtual User User { get; set; }
    }
}
