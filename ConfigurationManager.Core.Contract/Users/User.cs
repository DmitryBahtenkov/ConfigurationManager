using System.ComponentModel.DataAnnotations;
using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Core.Contract.Projects;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Core.Contract.Users;

[Index(nameof(Login))]
public class User : BaseModel
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Salt { get; set; }
    public List<Project> Projects { get; set; } 
}
