using App.Core.Entity.Abstract;
using MongoDB.Driver.Linq;

namespace App.Core.Infrastructure.Abstract;

public interface IMongoRepository<TDocument> : IGenericRepository<TDocument>
where TDocument : class, IMongoDocument, new()
{
    IMongoQueryable<TDocument> Queryable();
}

