using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager.Framework.CQRS.Pipelines
{
    public interface IInputCommandInterceptor<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
    {
        public Task Intercept(TCommand command, CancellationToken cancellationToken);
    }

    public interface IOutputCommandInterceptor<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
    {
        public Task Intercept(TCommand command, TCommandResult commandResult, CancellationToken cancellationToken);
    }
}