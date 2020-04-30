using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        public UserLogin GetUserLoginByName(string userName)
        {
            var query =
               from user in _mycontext.Users
               join userLogin in _mycontext.UserLogins on user.UserLoginID equals userLogin.UserLoginID             
               select new { UserLogin = userLogin };
                      

            return query.Select(x => x.UserLogin)
                .Where(w => w.UserName.Equals(userName)).FirstOrDefault();
        }
    }
}
