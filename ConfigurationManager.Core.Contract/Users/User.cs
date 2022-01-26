using ConfigurationManager.Core.Contract.Models;
using ConfigurationManager.Core.Contract.Projects;

namespace ConfigurationManager.Core.Contract.Users;

public class User : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool IsAdmin { get; set; }
    public List<Project> Projects { get; set; } 
}
