using App.Core.Entity.Abstract;

namespace App.Core.Infrastructure.Mediatr;

public interface IRequest<TEntity> : MediatR.IRequest<TEntity> where TEntity : class, IEntity, new() { }
