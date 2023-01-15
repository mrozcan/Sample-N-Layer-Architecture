using App.Core.Configurations.Abstract;

namespace App.Core.Configurations.Concrete;

public class MongoConfig : IMongoConfig
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}

