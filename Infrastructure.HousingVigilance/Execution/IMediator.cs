using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Execution
{
    public interface IMediator
    {
        TResponse Request<TResponse>(IQuery<TResponse> request);
        ICommandResult Execute(ICommand command);
        ICommandResult<TResult> Execute<TResult>(ICommand<TResult> command);
    }
}
