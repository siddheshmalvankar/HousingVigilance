using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain
{
    public class Vehicle:BaseEntity
    {
        public Vehicle()
        {
           
        }
        public int VehicleID { get; set; }
        public char VehicleType { get; set; }
        public string VehicleNumber { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
       // public virtual ICollection<GateEntry> GetEntries { get; set; }
    }
}
