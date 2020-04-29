using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class VehicleRepository : Repository<Vehicle>,IVehicleRepository
    {
        HousingVigilanceContext _mycontext;
        public VehicleRepository(HousingVigilanceContext context):base(context)
        {
            _mycontext = context;
        }      
    }
}
