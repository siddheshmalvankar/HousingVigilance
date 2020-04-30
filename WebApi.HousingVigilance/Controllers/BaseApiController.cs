using Infra.HousingVigilance.Execution;
using Infra.HousingVigilance.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.HousingVigilance.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public BaseApiController(IMediator mediator, ILog log, IAuditLogger auditLogger)
        {
            Mediator = mediator;
            Log = log;
            AuditLogger = auditLogger;
        }

        protected IMediator Mediator { get; private set; }

        protected ILog Log { get; private set; }

        protected IAuditLogger AuditLogger { get; private set; }

        protected string GetIPAddress()
        {
          
            string ipaddress = string.Empty;
            ipaddress = HttpContext.Connection.LocalIpAddress.ToString();
            if (ipaddress == "" || ipaddress == null)
                ipaddress = HttpContext.Connection.RemoteIpAddress.ToString();

            return ipaddress;
        }
    }
}
