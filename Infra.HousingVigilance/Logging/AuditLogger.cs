using System;
using System.Collections.Generic;
using System.Text;
using DBAccess.HousingVigilance.Domain;
using DBAccess.HousingVigilance.Domain.Interfaces;

namespace Infra.HousingVigilance.Logging
{
   public  class AuditLogger : IAuditLogger
    {
        IUnitofWork _unitofWork;
        public AuditLogger(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        /// <summary>
        /// InfoSec : To Log the Audits (Changes related to user, roles, permission etc)
        /// </summary>
        /// <param name="auditLog"></param>
        public void LogAudit(AuditLog auditLog)
        {
            _unitofWork.AuditLogs.Add(auditLog);
            _unitofWork.Complete();
        }

        /// <summary>
        /// To log Browser Details for further reserence
        /// </summary>
        /// <param name="browserdetail"></param>
        public void LogBrowserDetails(BrowserCapability browserdetail)
        {
            _unitofWork.BrowserCapabilities.Add(browserdetail);
            _unitofWork.Complete();
        }
    }
}
