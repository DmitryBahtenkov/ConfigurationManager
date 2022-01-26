using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Projects.Queries
{
    public record GetProjectsQuery(string Name = null) : IQuery<List<Project>>;
}