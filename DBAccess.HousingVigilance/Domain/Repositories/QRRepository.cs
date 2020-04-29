using DBAccess.HousingVigilance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Repositories
{
    public class QRRepository : Repository<QR>, IQRRepository
    {
        HousingVigilanceContext _mycontext;
        public QRRepository(HousingVigilanceContext context) : base(context)
        {
            _mycontext = context;
        }
    }
}
