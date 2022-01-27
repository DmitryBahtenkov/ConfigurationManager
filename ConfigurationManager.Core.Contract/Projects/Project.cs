using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Core.Contract.Users;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Core.Contract.Projects;

[Index(nameof(Token))]
public class Project : BaseModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Token { get; set; }
    [Required]
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}