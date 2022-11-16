using App.Core.Entity.Abstract;
using System.Linq.Expressions;

namespace App.Core.Infrastructure.Abstract;

public interface IGenericRepository<TEntity> where TEntity : class, IEntity, new()
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
    IQueryable<TEntity> Queryable();

}
