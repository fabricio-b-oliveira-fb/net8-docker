using Knights.Challenge.Domain;
using Knights.Challenge.Domain.Model;
using Knights.Challenge.Repository.Data;
using System.Linq.Expressions;

namespace Knights.Challenge.Repository
{
    public class KnightsChallengeRepository : IKnightsChallengeRepository
    {
        private readonly MongoContext _mongoContext;

        public KnightsChallengeRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<Knight> CreateKnightAsync(Knight knight)
        {
            await _mongoContext.CreateAsync(knight);

            return knight;
        }

        public async Task<IEnumerable<Knight>> GetKnightsAsync(Expression<Func<Knight, bool>> filter)
        {
            return (await _mongoContext.GetAsync(filter));
        }

        public async Task<Knight> UpdateKnightAsync(string id, Knight knight)
        {
            var update = id.Equals(knight.Id);

            if (update)
            {
                await _mongoContext.UpdateAsync(id, knight);

                return knight;
            }

            knight.SetEntityState(false);

            return knight;
        }

        public async Task<string> DeleteKnightAsync(string id)
        {
            await _mongoContext.DeleteAsync(id);

            return id;
        }
    }
}
