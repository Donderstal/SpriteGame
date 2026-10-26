using System.Linq.Expressions;
using SpriteGame.Domain.Entities;

namespace SpriteGame.Persistence.Repositories;

public interface IEntityRepository<T> where T : class, IEntity
{
    Guid Add(T entity);
    
    void AddRange(IEnumerable<T> entities);
    
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);

    Task<List<T>> GetByExpressionAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includeProperties
    );

    Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    
    void DeleteAsync(T entity);
    
    void DeleteRange(IEnumerable<T> entities);
    
    Task SaveChangesAsync();
}