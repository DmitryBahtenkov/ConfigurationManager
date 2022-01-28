using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Users.Commands;

public record DeleteUserCommand([Required] int Id) : ICommand<User>;
