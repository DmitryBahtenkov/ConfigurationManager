using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Core.Contract.Users;

namespace ConfigurationManager.Core.Contract.Projects;

public class Project : BaseModel
{
    public string Name { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}