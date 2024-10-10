using AutoMapper;
using Knights.Challenge.Domain.Model;
using Knights.Challenge.DTO;
using Knights.Challenge.Service;
using Microsoft.AspNetCore.Mvc;


namespace Knights.Challenge.API.Controllers
{
    [Route("api/knights")]
    public class KnightsChallengeController : BaseController
    {
        public readonly IKnightsChallengeService _knightsService;
        public readonly IMapper _mapper;

        public KnightsChallengeController(
            IKnightsChallengeService knightsService
           ,IMapper mapper)
        {
            _knightsService = knightsService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetKnightsAsync()
        {
            var knights = await _knightsService.GetKnightsAsync();

            var knightsDto = _mapper.Map<IEnumerable<KnightTraitsDto>>(knights);

            return CustomResponse(knightsDto);
        }

        [HttpGet("filter=heroes")]
        public async Task<IActionResult> GetHeroesAsync()
        {
            var heroes = await _knightsService.GetHeroesAsync();

            var heroesDto = _mapper.Map<IEnumerable<KnightTraitsDto>>(heroes);

            return CustomResponse(heroesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKnightAsync([FromBody] KnightDto knightDto)
        {
            var knight = _mapper.Map<Knight>(knightDto);

            await _knightsService.CreateKnightAsync(knight);

            return CustomResponse("Knight has been created");
        }

        [HttpGet(":id")]
        public async Task<IActionResult> GetKnightAsync(string id)
        {
            var knight = await _knightsService.GetKnightAsync(id);

            var knightDto = _mapper.Map<KnightDto>(knight);

            return CustomResponse(knightDto);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> DeleteKnightAsync(string id)
        {
            await _knightsService.DeleteKnightAsync(id);

            return CustomResponse("Knight has been sent to The Hall of Heroes");
        }

        [HttpPut(":id/:nickname")]
        public async Task<IActionResult> UpdateKnightAsync(string id, string nickname)
        {
            await _knightsService.UpdateKnightAsync(id, nickname);

            return CustomResponse("Nickname has been changed");
        }
    }
}
