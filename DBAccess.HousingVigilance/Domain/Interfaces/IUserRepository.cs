using DBAccess.HousingVigilance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.HousingVigilance.Domain.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        bool IsUserExist(int userID);
        bool IsAppartmentEntryExist(string appartmentNumber);
        IEnumerable<UserViewModel> GetUserDetails(int pageIndex, int pageSize);
    }
}
