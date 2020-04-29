using System;
using System.Collections.Generic;
using System.Text;
using DBAccess.HousingVigilance.Domain.Interfaces;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
    {
        HousingVigilanceContext _mycontext;
        public UserLoginRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }
}
