namespace Application.DTO;

public class UpdateApiKeyRequest
{
    public string ApiKey { get; set; }
    public List<string> Roles { get; set; } // Atualização de roles
    public List<string> Scopes { get; set; } // Atualização de scopes
    public DateTime? Expiration { get; set; } // Nova data de expiração (opcional)
}
