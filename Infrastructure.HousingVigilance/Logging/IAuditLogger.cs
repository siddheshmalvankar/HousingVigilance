using DataAccess.HousingVigilance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HousingVigilance.Logging
{
    public interface IAuditLogger
    {
        void LogAudit(AuditLog auditLog);      
        void LogBrowserDetails(BrowserCapability browserdetail);
        
    }
}
