using App.Core.Entity.Abstract;

namespace App.Core.Infrastructure.Abstract;

public interface IEFRepository<TEntity> : IGenericRepository<TEntity>
where TEntity : class, IEntity, new()
{
    IQueryable<TEntity> Queryable();
}
