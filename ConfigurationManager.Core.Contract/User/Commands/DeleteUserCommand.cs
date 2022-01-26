using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.User.Commands;

public record DeleteUserCommand([Required] string Id) : ICommand<User>;
