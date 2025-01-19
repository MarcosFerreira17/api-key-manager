namespace Havel.Api.Controllers.v1;

using Application.DTO;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ApiKeyManagerController : ControllerBase
{
    /// <summary>
    /// Gera uma nova API Key associada a um owner e roles/scopes específicos.
    /// </summary>
    [HttpPost("generate")]
    public IActionResult GenerateApiKey([FromBody] GenerateApiKeyRequest request)
    {
        return StatusCode(501, "Not Implemented");
    }

    /// <summary>
    /// Valida uma API Key e retorna seus roles e scopes.
    /// </summary>
    [HttpGet("validate")]
    public IActionResult ValidateApiKey([FromQuery] string apiKey)
    {
        return StatusCode(501, "Not Implemented");
    }

    /// <summary>
    /// Revoga uma API Key, tornando-a inválida.
    /// </summary>
    [HttpDelete("revoke")]
    public IActionResult RevokeApiKey([FromQuery] string apiKey)
    {
        return StatusCode(501, "Not Implemented");
    }

    /// <summary>
    /// Retorna a lista de API Keys associadas a um owner específico.
    /// </summary>
    [HttpGet("list")]
    public IActionResult ListApiKeysByOwner([FromQuery] string ownerId)
    {
        return StatusCode(501, "Not Implemented");
    }

    /// <summary>
    /// Atualiza os scopes e roles de uma API Key existente.
    /// </summary>
    [HttpPut("update")]
    public IActionResult UpdateApiKey([FromBody] UpdateApiKeyRequest request)
    {
        return StatusCode(501, "Not Implemented");
    }

    /// <summary>
    /// Retorna os detalhes de uma API Key específica.
    /// </summary>
    [HttpGet("details")]
    public IActionResult GetApiKeyDetails([FromQuery] string apiKey)
    {
        return StatusCode(501, "Not Implemented");
    }
}
