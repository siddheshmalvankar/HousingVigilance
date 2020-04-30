using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class AuditLogRepository : Repository<AuditLog>, IAuditLogRepository
    {
        HousingVigilanceContext _mycontext;
        public AuditLogRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }

    public class BrowserCapabilityRepository : Repository<BrowserCapability>, IBrowserCapabilityRepository
    {
        HousingVigilanceContext _mycontext;
        public BrowserCapabilityRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }
}
