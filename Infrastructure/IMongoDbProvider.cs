using MongoDB.Driver;

namespace ShoeStore.Infrastructure
{
    public interface IMongoDbProvider
    {
        IMongoDatabase Database { get; }

        string ShoeCollectionName { get; }
    }
}