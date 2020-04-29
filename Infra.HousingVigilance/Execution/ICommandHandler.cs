using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public interface ICommandHandler<in TCommand> where TCommand:ICommand
    {
        ICommandResult Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand<TResult>
    {
        ICommandResult<TResult> Handle(TCommand command);
    }
}
