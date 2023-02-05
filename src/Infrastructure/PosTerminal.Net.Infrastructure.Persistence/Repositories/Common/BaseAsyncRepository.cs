using Microsoft.EntityFrameworkCore;

namespace CleanArc.Infrastructure.Persistence.Repositories.Common;

internal abstract class BaseAsyncRepository<T> where T:class

{
    public readonly ApplicationDbContext DbContext;
    protected DbSet<T> Entities { get; }
    protected virtual IQueryable<T> Table => Entities;
    protected virtual IQueryable<T> TableNoTracking => Entities.AsNoTrackingWithIdentityResolution();

    protected BaseAsyncRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        Entities = DbContext.Set<T>();
    }

    public Task<List<T>> ListAllAsync()
    {
        return Entities.ToListAsync();
    }

    public async Task AddAsync(T entity)
    { 
        await Entities.AddAsync(entity);
           
    }

    public Task UpdateAsync(T entity)
    {
        Entities.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        Entities.Remove(entity);
        return Task.CompletedTask;
    }
}