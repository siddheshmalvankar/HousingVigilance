﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.HousingVigilance.Domain.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        bool IsUserExist(int userID);
    }
}
