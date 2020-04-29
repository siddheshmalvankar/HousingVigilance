using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain
{
    public partial class AuditLog
    {
        public long AuditLogID { get; set; }
        public string ApplicationName { get; set; }
        public Nullable<bool> ActionStatus { get; set; }
        public string EventDescription { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> ApplicationUserID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
