using App.Core.Entity.Abstract;
using App.Core.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Core.Infrastructure.EntityFramework;

public abstract class Repository<TEntity, TDBContext> : IGenericRepository<TEntity>, IDisposable, IAsyncDisposable
where TDBContext : DbContext, new()
where TEntity : class, IEntity, new()
{
    private DbContext _context;
    private bool disposedValue;

    public Repository() => _context = new TDBContext();

    public void Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public async Task AddAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        => filter != null ? _context.Set<TEntity>().Where(filter).ToList() : _context.Set<TEntity>().ToList();

    public IQueryable<TEntity> Queryable()
        => _context.Set<TEntity>().AsQueryable();

    #region Dispose

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    #endregion
}

