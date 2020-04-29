using Infrastructure.HousingVigilance.Logging;
using Infrastructure.HousingVigilance.Logging.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Text;

namespace Infrastructure.HousingVigilance.Execution
{
    // Code to construct QueryHandler derived from https://github.com/jbogard/MediatR/blob/master/src/MediatR/Mediator.cs
    public class DefaultMediator : IMediator
    {
        private readonly ILog _log;
        private readonly IResolver _resolver;

        public DefaultMediator(IResolver resolver, ILog log)
        {
            _resolver = resolver;
            _log = log;
        }

        public TResponse Request<TResponse>(IQuery<TResponse> request)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var wrapperType = typeof(QueryHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _resolver.GetInstance(handlerType);

            if (handler == null)
            {
                throw new HandlerNotFoundException(request);
            }

            var wrapperHandler = (QueryHandler<TResponse>)Activator.CreateInstance(wrapperType, handler);

            return wrapperHandler.Handle(request);
        }

        public ICommandResult Execute(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var wrapperType = typeof(NoResultCommandHandler<>).MakeGenericType(command.GetType());
            var handler = _resolver.GetInstance(handlerType);

            if (handler == null)
            {
                throw new HandlerNotFoundException(command);
            }

            var wrapperHandler = (NoResultCommandHandler)Activator.CreateInstance(wrapperType, handler);

            try
            {
                return wrapperHandler.Handle(command);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _log.WriteLog(LogEventType.Warning, ex.Message);
                throw new ConcurrencyException(ex);
            }
        }

        public ICommandResult<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var wrapperType = typeof(CommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            var handler = _resolver.GetInstance(handlerType);

            if (handler == null)
            {
                throw new HandlerNotFoundException(command);
            }

            var wrapperHandler = (CommandHandler<TResult>)Activator.CreateInstance(wrapperType, handler);

            try
            {
                return wrapperHandler.Handle(command);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _log.WriteLog(LogEventType.Warning, ex.Message);
                throw new ConcurrencyException(ex);
            }
        }
    }
}
