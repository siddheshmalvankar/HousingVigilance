using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
   public class GateEntryRepository : Repository<GateEntry>, IGateEntryRepository
    {
        HousingVigilanceContext _mycontext;
        public GateEntryRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }
}
