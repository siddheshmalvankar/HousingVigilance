using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public abstract class CommandHandler<TResult>
    {
        public abstract ICommandResult<TResult> Handle(ICommand<TResult> message);
    }

    public class CommandHandler<TCommand, TResult> : CommandHandler<TResult> where TCommand : ICommand<TResult>
    {
        private readonly ICommandHandler<TCommand, TResult> _inner;

        public CommandHandler(ICommandHandler<TCommand, TResult> inner)
        {
            _inner = inner;
        }

        public override ICommandResult<TResult> Handle(ICommand<TResult> message)
        {
            return _inner.Handle((TCommand)message);
        }
    }
}
