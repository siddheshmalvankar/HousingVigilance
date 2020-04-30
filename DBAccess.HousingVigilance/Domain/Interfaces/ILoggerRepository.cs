using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Interfaces
{
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
    }

    public interface IBrowserCapabilityRepository : IRepository<BrowserCapability>
    {
    }
}
