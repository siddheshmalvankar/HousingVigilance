using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public class GateEntry:BaseEntity
    {
        public int GeteID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int VehicleID { get; set; }      
    }
}
