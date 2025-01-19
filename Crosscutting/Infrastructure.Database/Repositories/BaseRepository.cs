using System.Linq.Expressions;
using Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class BaseRepository<TEntity, TContext>: IBaseRepository<TEntity> where TEntity : class where TContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly TContext context;
    private readonly DbSet<TEntity> dbSet;

    public BaseRepository(TContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }
    
    public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }

    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
    {
        throw new NotImplementedException();
    }

    public virtual TEntity GetById(object id)
    {
        return dbSet.Find(id);
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}