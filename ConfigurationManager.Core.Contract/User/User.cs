using ConfigurationManager.Core.Contract.Models;

namespace ConfigurationManager.Core.Contract.User;

public class User : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool IsAdmin { get; set; }
    public List<Project> Projects { get; set; } 
}
