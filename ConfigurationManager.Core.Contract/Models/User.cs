namespace ConfigurationManager.Core.Contract.Models;

public class User : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool IsAdmin { get; set; }
    public List<Project> Projects { get; set; } 
}
