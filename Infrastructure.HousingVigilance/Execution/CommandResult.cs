using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Execution
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public static CommandResult OK() { return new CommandResult() { Success = true }; }
        public static CommandResult Fail() { return new CommandResult() { Success = false }; }
        public static CommandResult<TResult> OK<TResult>(TResult result) { return new CommandResult<TResult>() { Success = true, Result = result }; }
        public static CommandResult<TResult> Fail<TResult>(TResult result) { return new CommandResult<TResult>() { Success = false, Result = result }; }
    }

    public class CommandResult<TResult> : ICommandResult<TResult>
    {
        public bool Success { get; set; }
        public TResult Result { get; set; }

        public static CommandResult<TResult> Fail() { return new CommandResult<TResult>() { Success = false, Result = default(TResult) }; }
    }
}
