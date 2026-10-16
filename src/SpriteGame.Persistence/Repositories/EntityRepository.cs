using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SpriteGame.Domain.Entities;

namespace SpriteGame.Persistence.Repositories;

public class EntityRepository<T>(SpriteGameDbContext dbContext) : IEntityRepository<T> where T : class, IEntity
{
    public Guid Add(T entity)
    {
        var addedEntity = dbContext.Add(entity);
        return addedEntity.Entity.Id;
    }
    
    public void AddRange(IEnumerable<T> entities)
    {
        dbContext.AddRange(entities);
    }
    
    /// <summary>
    /// Get a single T entity by id
    /// </summary>
    /// <param name="id">Guid id to match</param>
    /// <param name="includeProperties">entity => entity.childEntity</param>
    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = IncludeProperties(dbContext.Set<T>(), includeProperties);
        return await query.SingleOrDefaultAsync(entity => entity.Id == id);
    }

    /// <summary>
    /// Get a list of T entities by a filter expression
    /// </summary>
    /// <param name="predicate">entity => entity.property == value</param>
    /// <param name="includeProperties">entity => entity.childEntity</param>
    public Task<List<T>> GetByExpressionAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includeProperties)
    {
        var query = IncludeProperties(dbContext.Set<T>(), includeProperties);
        return query.Where(predicate).ToListAsync();
    }

    /// <summary>
    /// Get all known T entities
    /// </summary>
    /// <param name="includeProperties">entity => entity.childEntity</param>
    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
    {
        var query = IncludeProperties(dbContext.Set<T>(), includeProperties);
        return await query.ToListAsync();
    }

    public void DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().RemoveRange(entities);
    }
    
    private static IQueryable<T> IncludeProperties(
        IQueryable<T> query,
        params Expression<Func<T, object>>[] includeProperties)
    {
        return includeProperties.Aggregate(
            query, 
            (current, includeProperty) => current.Include(includeProperty)
        );
    }
}