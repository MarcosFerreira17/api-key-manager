using Domain.Entities;
using Infrastructure.Database.DbContext;
using Infrastructure.Database.Repositories.Interfaces;

namespace Infrastructure.Database.Repositories;

public class ApiUserRepository : BaseRepository<ApiUser, ApplicationDbContext>, IApiUserRepository
{
    public ApiUserRepository(ApplicationDbContext context) : base(context)
    {
    }
}