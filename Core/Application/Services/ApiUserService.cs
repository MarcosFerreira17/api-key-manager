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
    
    public async Task<Guid> CreateAsync(CreateUserRequest request)
    {
        string apiKey = Guid.NewGuid().ToString();
        
        ApiUser entity = new(request.Username, request.Email, apiKey);
        
        await _apiUserRepository.CreateAsync(entity);

        _apiUserRepository.SaveAsync();

        return entity.Id;
    }

}