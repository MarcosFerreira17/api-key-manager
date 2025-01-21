using Application.ApiUserEvents.Commands.CreateUser.Interfaces;
using Application.DTO;
using Domain.Entities;
using Infrastructure.Database.Repositories.Interfaces;

namespace Application.Services;

public class ApiUserService : IApiUserService
{
    private readonly IApiUserRepository _apiUserRepository;

    public ApiUserService(IApiUserRepository apiUserRepository)
    {
        _apiUserRepository = apiUserRepository ?? throw new ArgumentNullException(nameof(apiUserRepository));
    }

    public Task<Guid> CreateAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<string> IsValidApiKey(string apiKey)
    {
        throw new NotImplementedException();
    }

    public Task RevokeAsync(string apiKey)
    {
        throw new NotImplementedException();
    }

    public Task RotateAsync(string apiKey)
    {
        throw new NotImplementedException();
    }
}