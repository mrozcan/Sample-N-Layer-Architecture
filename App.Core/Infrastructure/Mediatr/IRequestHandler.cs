using App.Core.Entity.Abstract;

namespace App.Core.Infrastructure.Mediatr;

public interface IRequestHandler<TRequest, IEntityUnit> : MediatR.IRequestHandler<TRequest, IEntityUnit>
where TRequest : class, IRequest<IEntityUnit>, new()
where IEntityUnit : class, IEntity, new()
{ }
