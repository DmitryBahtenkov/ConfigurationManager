using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Configurations.Commands
{
    public class CreateConfigurationCommand : ICommand<Configuration>
    {
        public string Environment { get; set; }
        public JsonDocument Json { get; set; }
        public int ProjectId { get; set; }
    }
}