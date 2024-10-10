using Knights.Challenge.Domain.Model;
using System.Linq.Expressions;

namespace Knights.Challenge.Domain
{
    public interface IKnightsChallengeRepository
    {
        Task<Knight> CreateKnightAsync(Knight knight);        
        Task<IEnumerable<Knight>> GetKnightsAsync(Expression<Func<Knight, bool>> filter);
        Task<Knight> UpdateKnightAsync(string id, Knight knight);
        Task<string> DeleteKnightAsync(string id);
    }
}