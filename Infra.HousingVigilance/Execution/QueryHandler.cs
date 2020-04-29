using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public abstract class QueryHandler<TResult>
    {
        public abstract TResult Handle(IQuery<TResult> message);
    }

    public class QueryHandler<TCommand, TResult> : QueryHandler<TResult> where TCommand : IQuery<TResult>
    {
        private readonly IQueryHandler<TCommand, TResult> _inner;

        public QueryHandler(IQueryHandler<TCommand, TResult> inner)
        {
            _inner = inner;
        }

        public override TResult Handle(IQuery<TResult> message)
        {
            return _inner.Handle((TCommand)message);
        }
    }
}
