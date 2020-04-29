using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Logging.Exceptions
{
    public class ConcurrencyException : ApplicationException
    {
        private DbUpdateConcurrencyException frameworkException { get; set; }

        public ConcurrencyException(DbUpdateConcurrencyException exception)
        {
            frameworkException = exception;
        }
    }
}
