namespace Domain.Entities;

public class ApiUser : BaseEntity
{
    public string Owner  { get; private set; }
    public string Email { get; private set; }
    public string ApiKey { get; private set; }

    public ApiUser(string owner, string email, string apiKey) : base()
    {
        Owner = owner;
        Email = email;
        ApiKey = apiKey;
    }
}