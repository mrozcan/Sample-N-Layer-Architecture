using App.Core.Configurations.Abstract;
using App.Core.Infrastructure.MongoDB;
using App.Domain.Documents;
using App.Infrastructure.ORMs.Mongo.Abstract;

namespace App.Infrastructure.ORMs.Mongo.Concrete;
public class SampleDocumentRepositoryDal : MongoRepository<SampleDocument>, ISampleDocumentRepository
{
    public SampleDocumentRepositoryDal(IMongoConfig configuration) : base(configuration) { }
}

