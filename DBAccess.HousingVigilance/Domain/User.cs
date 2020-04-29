using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain
{
    public class User:BaseEntity
    {
        public User()
        {
            this.Vehicle=new List<Vehicle>();
            this.GetEntries = new List<GateEntry>();          
        }
        public int UserID { get; set; }
        public char UserType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AppartmentNumber { get; set; }
        public int ContactNumber1 { get; set; }
        public int ContactNumber2 { get; set; }
        public string PrimaryEmail { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
       
        public int QRId { get; set; }
        public virtual QR Qr { get; set; }

        public int RoleID { get; set; }
        public virtual Role Role { get; set; }


        public virtual ICollection<GateEntry> GetEntries { get; set; }

    


    }
}
