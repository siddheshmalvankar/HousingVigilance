using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public class QR:BaseEntity
    {
        public QR()
        {
           
        }
        public int QrID { get; set; }
        public string QrUniqueId { get; set; }
        public byte[] QrCode { get; set; }      
        public virtual User User { get; set; }

    }
}
