using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        HousingVigilanceContext _mycontext;
        public PermissionRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }
}
