using GrpcService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GrpcService.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public IMongoCollection<Measurement> _measurementsCollection;
        public MongoDbContext(IOptions<MongoDbConfiguration> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
            _measurementsCollection = _database.GetCollection<Measurement>(settings.Value.CollectionName);
        }

    }
}
