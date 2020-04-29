using DBAccess.HousingVigilance.Domain;
using DBAccess.HousingVigilance.Domain.Interfaces;
using DBAccess.HousingVigilance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DBAccess.HousingVigilance.Domain
{
    public class UnitofWork<TEntity> : IUnitofWork
    {
        private bool disposed;
        protected readonly HousingVigilanceContext Context;
        public UnitofWork(HousingVigilanceContext context)
        {
            Context = context;
            Vehicles = new VehicleRepository(context);
            Users = new UserRepository(context);
            Roles = new RoleRepository(context);
            Permissions = new PermissionRepository(context);
            GateEntries = new GateEntryRepository(context);
            QRcodes = new QRRepository(context);
            UserLogins = new UserLoginRepository(context);

        }
        public IVehicleRepository Vehicles { get; }

        public IUserRepository Users { get; }

        public IRoleRepository Roles { get; }

        public IPermissionRepository Permissions { get; }

        public IGateEntryRepository GateEntries { get; }

        public IQRRepository QRcodes { get; }

        public IUserLoginRepository UserLogins { get; }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if (disposing)
                    Context.Dispose();
            }
            disposed = true;
        }
        public void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ExecuteReader(string sqlQuery)
        {
            try
            {
                return new List<object>();

            }
            catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<object> ExecuteReader(string storedProcedureName, SqlParameter[] parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
