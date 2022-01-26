using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Projects.Commands
{
    public class CreateUpdateProjectCommand : ICommand<Project>
    {
        public string Name { get; set; }
    }
}