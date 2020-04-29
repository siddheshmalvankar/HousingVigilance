using DBAccess.HousingVigilance.Domain;
using DBAccess.HousingVigilance.ViewModels;
using Infra.HousingVigilance.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExecService.HousingVigilance.Queries
{
    public class UserQuery:IQuery<IEnumerable<UserViewModel>>
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

    }
}
