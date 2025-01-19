using System.Linq.Expressions;

namespace Infrastructure.Database.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    public T GetById(object id);
    public Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    public Task CreateAsync(T entity);
    public Task RemoveAsync(T entity);
    public Task SaveAsync();
}
