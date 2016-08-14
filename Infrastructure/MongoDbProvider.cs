using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShoeStore.Models;

namespace ShoeStore.Infrastructure
{
    public class MongoDbProvider : IMongoDbProvider
    {
        private readonly IOptions<DatabaseSettings> _settings;
        private readonly IMongoClient _client;

        public MongoDbProvider(IOptions<DatabaseSettings> settings)
        {
            _settings = settings;

            var mongoSettings = new MongoClientSettings
                {
                    Server = new MongoServerAddress(settings.Value.MongoDbServer),
                    WriteConcern = WriteConcern.W1
                };
                
            _client = new MongoClient(mongoSettings);

            PopulateSeedData();
        }

        public IMongoDatabase Database 
        { 
            get 
            {
                var databaseName = _settings.Value.DatabaseName;
                return _client.GetDatabase(databaseName); 
            }
        }

        public string ShoeCollectionName => "Shoes";

        private void PopulateSeedData()
        {
            var shoeCollection = Database.GetCollection<Shoe>(ShoeCollectionName);

            var filter = Builders<Shoe>.Filter.Empty;
            if (shoeCollection.Count(filter) > 0) return;
            
            shoeCollection.InsertMany(new [] {
                new Shoe { Name = "Ghost 9", Brand = "Brooks", Gender = Gender.Male, Size = 10.5m, Price = 100 },
                new Shoe { Name = "Multi ZX Flux", Brand = "Adidas", Gender = Gender.Female, Size = 8, Price = 89.99m },
                new Shoe { Name = "Kayano 23", Brand = "ASICS", Gender = Gender.Male, Size = 9, Price = 159.59m },
                new Shoe { Name = "Pegasus", Brand = "Nike", Gender = Gender.Male, Size = 11, Price = 120 },
                new Shoe { Name = "Wave Rider 19", Brand = "Mizuno", Gender = Gender.Female, Size = 9, Price = 119.95m },
                new Shoe { Name = "Clifton 3", Brand = "Hoka One One", Gender = Gender.Female, Size = 9, Price = 129.95m }
            });
        }
    }
}