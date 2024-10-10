using Knights.Challenge.Domain;
using Knights.Challenge.Domain.Model;

namespace Knights.Challenge.Service
{
    public class KnightsChallengeService : IKnightsChallengeService
    {
        public IKnightsChallengeRepository _knightsRepository;

        public KnightsChallengeService(IKnightsChallengeRepository knightsRepository)
        {
            _knightsRepository = knightsRepository;
        }

        public async Task<Knight> CreateKnightAsync(Knight knight)
        {
            knight.SetTraits();

            return await _knightsRepository.CreateKnightAsync(knight);
        }

        public async Task<IEnumerable<KnightTraits>> GetKnightsAsync(string filter = "")
        {
            IEnumerable<Knight> knights;

            if (string.IsNullOrWhiteSpace(filter))
            {
                knights = await _knightsRepository.GetKnightsAsync(x => !x.IsHero);
            }

            knights = await _knightsRepository.GetKnightsAsync(x =>
                !x.IsHero && (x.Name.Contains(filter) || x.Nickname.Contains(filter)));

            return await GetKnightsAsync(knights);
        }

        public async Task<IEnumerable<KnightTraits>> GetHeroesAsync()
        {
            var knights = await _knightsRepository.GetKnightsAsync(x => x.IsHero);

            return await GetKnightsAsync(knights);
        }

        private async Task<IEnumerable<KnightTraits>> GetKnightsAsync(IEnumerable<Knight> knights)
        {
            return await Task.Run(() =>
            {
                var KnightTraits = knights?.Select(x => new KnightTraits()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Nickname = x.Nickname,
                    Age = x.Age,
                    Weapons = x.QuantityOfWeapons,
                    Attribute = x.KeyAttribute,
                    Attack = x.Attack,
                    Experience = x.Experience,
                    IsHero = x.IsHero,
                });

                return KnightTraits ?? [];
            });
        }        

        public async Task<Knight> GetKnightAsync(string id)
        {
            var result = await _knightsRepository.GetKnightsAsync(x => id.Equals(x.Id));

            if (result is null) return default;

            return result.FirstOrDefault();
        }        

        public async Task<Knight> UpdateKnightAsync(string id, string nickname)
        {
            var knight = await GetKnightAsync(id);

            knight.SetTraits();

            knight.UpdateNickname(nickname);

            return await _knightsRepository.UpdateKnightAsync(id, knight);
        }

        public async Task<Knight> DeleteKnightAsync(string id)
        {
            var knight = await GetKnightAsync(id);

            knight.SendToTheHallOfHeroes();

            return await _knightsRepository.UpdateKnightAsync(id, knight);
        }
    }
}
