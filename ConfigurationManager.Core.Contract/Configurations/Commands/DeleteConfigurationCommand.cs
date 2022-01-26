using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Configurations.Commands
{
    public record DeleteConfigurationCommand(string Id) : ICommand<Configuration>;
}