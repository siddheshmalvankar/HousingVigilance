using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        HousingVigilanceContext _mycontext;
        public RoleRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }
}
