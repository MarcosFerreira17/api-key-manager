using Application.DTO;

namespace Application.ApiUserEvents.Commands.CreateUser.Interfaces;

public interface IApiUserService
{
    public Task<string> IsValidApiKey(string apiKey);
    public Task<Guid> CreateAsync(CreateUserRequest request);
    public Task RevokeAsync(string apiKey);
    public Task RotateAsync(string apiKey);
}