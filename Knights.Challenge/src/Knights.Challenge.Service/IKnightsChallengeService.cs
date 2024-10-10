using Knights.Challenge.Domain.Model;

namespace Knights.Challenge.Service
{
    public interface IKnightsChallengeService
    {
        Task<Knight> CreateKnightAsync(Knight knight);
        Task<IEnumerable<KnightTraits>> GetHeroesAsync();
        Task<IEnumerable<KnightTraits>> GetKnightsAsync(string filter = "");
        Task<Knight> GetKnightAsync(string id);
        Task<Knight> DeleteKnightAsync(string id);
        Task<Knight> UpdateKnightAsync(string id, string nickname);
    }
}
