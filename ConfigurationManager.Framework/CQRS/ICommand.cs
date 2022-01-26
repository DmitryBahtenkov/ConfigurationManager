using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ConfigurationManager.Framework.CQRS;

public interface ICommand<out TCommandResult> : IRequest<TCommandResult> { }
public interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult> { }