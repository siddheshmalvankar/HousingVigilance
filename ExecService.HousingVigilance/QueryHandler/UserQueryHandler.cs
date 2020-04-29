using DBAccess.HousingVigilance.Domain;
using DBAccess.HousingVigilance.Domain.Interfaces;
using DBAccess.HousingVigilance.ViewModels;
using ExecService.HousingVigilance.Queries;
using Infra.HousingVigilance.Execution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExecService.HousingVigilance.QueryHandler
{
    public class UserQueryHandler : IQueryHandler<UserQuery, IEnumerable<UserViewModel>>
    {
        IUnitofWork _unitofWork;
        public UserQueryHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IEnumerable<UserViewModel> Handle(UserQuery query)        {
            
            return _unitofWork.Users.GetUserDetails(query.pageIndex, query.pageSize);               
           
        }
    }
}
