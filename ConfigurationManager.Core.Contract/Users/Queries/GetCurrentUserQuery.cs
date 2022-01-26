using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Users.Queries
{
    public record GetCurrentUserQuery : IQuery<User>
    {
        public static GetCurrentUserQuery New => new GetCurrentUserQuery();
    }
}