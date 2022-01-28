using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Framework.CQRS;

namespace ConfigurationManager.Core.Contract.Users.Commands;
public record UpdateUserCommand : ICommand<User>
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public bool IsAdmin { get; set; }
}
