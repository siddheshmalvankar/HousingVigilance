using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Logging.Exceptions
{
    public class HandlerNotFoundException : ApplicationException
    {
        public Type CommandQueryType { get; set; }

        public HandlerNotFoundException(object commandQueryInstance)
            : base(String.Format("No Handler found for {0}.", commandQueryInstance.GetType().Name))
        {
            CommandQueryType = commandQueryInstance.GetType();
        }
    }
}
