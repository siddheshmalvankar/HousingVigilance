using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBAccess.HousingVigilance.Domain.Interfaces
{
    public interface IUnitofWork : IDisposable 
    {
        IVehicleRepository Vehicles { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IPermissionRepository Permissions { get; }
        IGateEntryRepository GateEntries { get; }
        IQRRepository QRcodes { get; }
        IUserLoginRepository UserLogins { get; }

        IAuditLogRepository AuditLogs { get; }

        IBrowserCapabilityRepository BrowserCapabilities { get; }


        IEnumerable<object> ExecuteReader(string sqlQuery);

        IEnumerable<object> ExecuteReader(string storedProcedureName, SqlParameter[] parameters =null);

        void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null);

        int Complete();
    }
}
