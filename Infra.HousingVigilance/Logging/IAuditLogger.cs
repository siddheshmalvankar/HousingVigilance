using DBAccess.HousingVigilance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.HousingVigilance.Logging
{
    public interface IAuditLogger
    {
        void LogAudit(AuditLog auditLog);      
        void LogBrowserDetails(BrowserCapability browserdetail);
        
    }
}
