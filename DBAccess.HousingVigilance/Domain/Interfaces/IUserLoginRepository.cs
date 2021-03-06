﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Interfaces
{
    public interface IUserLoginRepository:IRepository<UserLogin>
    {
        UserLogin GetUserLoginByName(string userName);
    }
}
