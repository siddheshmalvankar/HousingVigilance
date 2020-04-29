using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Execution
{
   public interface ICommandResult
    {
        bool Success { get; set; }
    }

    public interface ICommandResult<out TResult> : ICommandResult
    {
        TResult Result { get; }
    }
}
