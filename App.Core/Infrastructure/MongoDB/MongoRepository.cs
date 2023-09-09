using App.Core.Configurations.Abstract;
using App.Core.Entity.Abstract;
using App.Core.Infrastructure.Abstract;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace App.Core.Infrastructure.MongoDB;

public abstract class MongoRepository<TDocument> : IMongoRepository<TDocument>
where TDocument : class, IMongoDocument, new()
{

    private IMongoCollection<TDocument> _mongoCollection;

    public MongoRepository(IMongoConfig configuration, string collectionName)
    {
        _mongoCollection = new MongoClient(configuration.ConnectionString)
        .GetDatabase(configuration.DatabaseName)
        .GetCollection<TDocument>(collectionName);
    }

    public MongoRepository(string connectionString, string databaseName, string collectionName)
    {
        _mongoCollection = new MongoClient(connectionString)
        .GetDatabase(databaseName)
        .GetCollection<TDocument>(collectionName);
    }

    public void Add(TDocument document)
    {
        _mongoCollection.InsertOne(document);
    }

    public async Task AddAsync(TDocument document)
    {
        await _mongoCollection.InsertOneAsync(document);
    }

    public void Delete(TDocument document)
    {
        _mongoCollection.FindOneAndDelete(x => x.Id == document.Id);
    }

    public async Task DeleteAsync(TDocument document)
    {
        await _mongoCollection.FindOneAndDeleteAsync(x => x.Id == document.Id);
    }

    public void Update(TDocument document)
    {
        _mongoCollection.ReplaceOne(x => x.Id == document.Id, document);
    }

    public async Task UpdateAsync(TDocument document)
    {
        await _mongoCollection.ReplaceOneAsync(x => x.Id == document.Id, document);
    }

    public IList<TDocument> GetAll(Expression<Func<TDocument, bool>>? filter = null)
        => filter != null ? _mongoCollection.AsQueryable().Where(filter).ToList() : _mongoCollection.AsQueryable().ToList();

    public IMongoQueryable<TDocument> Queryable()
        => _mongoCollection.AsQueryable();
}