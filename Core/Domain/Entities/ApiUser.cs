namespace Domain.Entities;

public class ApiUser : BaseEntity
{
    public Owner Owner { get; private set; }
    public List<Scope> Scope { get; private set; }
    public List<Role> Roles { get; private set; }
    public string ApiKey { get; private set; }
}