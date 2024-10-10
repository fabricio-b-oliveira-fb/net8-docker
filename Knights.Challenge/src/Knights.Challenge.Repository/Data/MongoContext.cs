using Knights.Challenge.Domain.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Knights.Challenge.Repository.Data
{
    public class MongoContext
    {
        private readonly IMongoCollection<Knight> _KnightsCollection;

        public MongoContext(IOptions<KnightsChallengeDataBaseSettings> KnightStoreDatabaseSettings)
        {
            var value = KnightStoreDatabaseSettings.Value;
            var client = new MongoClient(value.ConnectionString);

            var database = client.GetDatabase(value.DatabaseName);
            _KnightsCollection = database.GetCollection<Knight>(value.KnightsCollectionName);                                                  
        }

        public async Task CreateAsync(Knight knight) =>
            await _KnightsCollection.InsertOneAsync(knight);

        public async Task<List<Knight>> GetAsync(Expression<Func<Knight, bool>> filter) =>
           await _KnightsCollection.Find(filter).ToListAsync();
        
        public async Task DeleteAsync(string id) => 
            await _KnightsCollection.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(string id, Knight knight) =>
            await _KnightsCollection.ReplaceOneAsync(x => id.Equals(x.Id), knight);        
    }
}
