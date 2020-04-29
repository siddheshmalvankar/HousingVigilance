using DBAccess.HousingVigilance.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



namespace Infra.HousingVigilance.Execution
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private HousingVigilanceContext _context;

        public DatabaseFactory(HousingVigilanceContext dbcontext)
        {
            _context = dbcontext;
        }
        /// <summary>
        /// this method will be used to execute stored procedure along with timeout if given
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<TResult> ExecuteStoredProcedure<TResult>(string commandText, int? timeout, params object[] parameters)
        {
            var hasOutputParameters = false;
            int? previousTimeout = null;

         

            if (parameters != null)
            {
                foreach (var outputP in parameters.OfType<DbParameter>())
                {
                    outputP.Value = outputP.Value ?? DBNull.Value;

                    if (outputP.Direction == ParameterDirection.InputOutput ||
                        outputP.Direction == ParameterDirection.Output)
                    {
                        hasOutputParameters = true;
                    }
                }
            }

            var context = ((IObjectContextAdapter)this._context).ObjectContext;
            if (timeout.HasValue)
            {
                // store previous timeout
                previousTimeout = context.CommandTimeout;
                context.CommandTimeout = timeout;
            }

            if (!hasOutputParameters)
            {
                // no output parameters
                var result = context.ExecuteStoreQuery<TResult>(commandText, parameters).ToList();
                if (timeout.HasValue)
                {
                    // Set previous timeout back
                    context.CommandTimeout = previousTimeout;
                }

                return result;
            }

            var connection = ((EntityConnection)context.Connection).StoreConnection;

            // Don't close the connection after command execution open the connection for use
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            // create a command object
            using (var cmd = connection.CreateCommand())
            {
                // command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                // move parameters to command object
                foreach (var p in parameters)
                {
                    cmd.Parameters.Add(p);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    var result = context.Translate<TResult>(reader).ToList();
                    if (timeout.HasValue)
                    {
                        // Set previous timeout back
                        context.CommandTimeout = previousTimeout;
                    }
                    return result;
                }
            }
        }

        // Flag: Has Dispose already been called? 
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                if (_context != null) _context.Dispose();
                if (sqlConnection != null) sqlConnection.Dispose();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }

    }
}
