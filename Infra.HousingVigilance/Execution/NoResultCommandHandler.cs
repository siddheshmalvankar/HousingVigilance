using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public abstract class NoResultCommandHandler
    {
        public abstract ICommandResult Handle(ICommand message);
    }

    public class NoResultCommandHandler<TCommand> : NoResultCommandHandler where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _inner;

        public NoResultCommandHandler(ICommandHandler<TCommand> inner)
        {
            _inner = inner;
        }

        public override ICommandResult Handle(ICommand message)
        {
            return _inner.Handle((TCommand)message);
        }
    }
}
