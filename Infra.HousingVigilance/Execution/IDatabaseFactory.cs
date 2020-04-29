using DBAccess.HousingVigilance.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public interface IDatabaseFactory : IDisposable
    {
        // Most queries through EFContext
        HousingVigilanceContext GetContext(bool _isLazyLoadingEnabled = false);
        HousingVigilanceContext GetDisposableContext();

        // Some operations may need to go straight to the DB for optimisation
        SqlConnection GetSQLConnection();

        /// <summary>
        /// this method will be used to execute stored procedure along with timeout if given
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<TResult> ExecuteStoredProcedure<TResult>(string commandText, int? timeout, params object[] parameters);
    }
}
