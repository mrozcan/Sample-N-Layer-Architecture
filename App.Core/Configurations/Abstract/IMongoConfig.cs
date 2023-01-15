namespace App.Core.Configurations.Abstract;

public interface IMongoConfig
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}

