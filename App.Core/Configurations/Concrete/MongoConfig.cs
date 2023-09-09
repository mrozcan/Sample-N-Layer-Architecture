using App.Core.Configurations.Abstract;

namespace App.Core.Configurations.Concrete;

public class MongoConfig : IMongoConfig
{
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}

