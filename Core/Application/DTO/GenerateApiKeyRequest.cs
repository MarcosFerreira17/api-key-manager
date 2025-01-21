namespace Application.DTO;

public class GenerateApiKeyRequest
{
    public string OwnerId { get; set; } // Dono da API Key
    public List<string> Roles { get; set; } // Roles atribuídas
    public List<string> Scopes { get; set; } // Scopes permitidos
    public DateTime? Expiration { get; set; } // Data de expiração (opcional)
}
