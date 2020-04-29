using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.HousingVigilance.Execution
{
    public interface IQueryHandler<in TQuery,out TResponse> where TQuery:IQuery<TResponse>
    {
        TResponse Handle(TQuery query);
    }
}
