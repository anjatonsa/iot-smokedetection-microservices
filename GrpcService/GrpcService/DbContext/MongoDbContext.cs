using GrpcService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GrpcService.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbConfiguration> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Measurement> Measurments =>
       _database.GetCollection<Measurement>("Measurments");


    }
}
