using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DBAccess.HousingVigilance.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        HousingVigilanceContext _mycontext;

       
        public UserRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }

        public bool IsAppartmentEntryExist(string appartmentNumber)
        {
            return _mycontext.Set<User>().Any(x => x.AppartmentNumber.Equals(appartmentNumber.Trim()));
        }

        public bool IsUserExist(int userID)
        {
            return _mycontext.Set<User>().Any(x => x.UserID.Equals(userID));
        }

        public IEnumerable<UserViewModel> GetUserDetails(int pageIndex, int pageSize)
        {
                var query =
                from user in _mycontext.Users
                join role in _mycontext.Roles on user.RoleID equals role.RoleID
                join qr in _mycontext.QRCodes on user.QRId equals qr.QrID
                select new { User = user, Role = role, QR=qr };

            var result = (_mycontext.Users
                .Include(q => q.Qr)
                .Include(r => r.Role)
                .OrderBy(u => u.AppartmentNumber)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)).ToList();

            return query.Select(x => new UserViewModel()
            {
               QRId=x.QR.QrID,
               QrCode=x.QR.QrCode,
               QrUniqueId=x.QR.QrUniqueId,
               RoleID=x.Role.RoleID,
               RoleDesc=x.Role.RoleDesc,
               RoleName=x.Role.RoleName,
               UserID=x.User.UserID,
               AppartmentNumber=x.User.AppartmentNumber,
               ContactNumber1=x.User.ContactNumber1,
               ContactNumber2=x.User.ContactNumber2,
               FirstName=x.User.FirstName,
               LastName=x.User.LastName,
               UserType=x.User.UserType,
               MiddleName=x.User.MiddleName,
               PrimaryEmail=x.User.PrimaryEmail
            }).ToList();
        }
    }
}
