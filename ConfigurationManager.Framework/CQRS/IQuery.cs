using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ConfigurationManager.Framework.CQRS;
public interface IQuery<out TQueryResult> : IRequest<TQueryResult> { }
interface IQueryHandler<in TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult> { }
