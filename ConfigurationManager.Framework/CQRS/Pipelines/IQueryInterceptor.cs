using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager.Framework.CQRS.Pipelines;

public interface IInputQueryInterceptor<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
{
    public Task Intercept(TQuery query, CancellationToken cancellationToken);
}

public interface IOutputQueryInterceptor<TQuery, TQueryResult>
{
    public Task Intercept(TQuery query, TQueryResult queryResult, CancellationToken cancellationToken);
}