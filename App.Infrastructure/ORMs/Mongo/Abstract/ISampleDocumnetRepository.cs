using App.Core.Infrastructure.Abstract;
using App.Domain.Documents;

namespace App.Infrastructure.ORMs.Mongo.Abstract
{
    public interface ISampleDocumentRepository : IMongoRepository<SampleDocument>
    {
    }
}
