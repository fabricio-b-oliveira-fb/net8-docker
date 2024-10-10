using AutoMapper;
using Knights.Challenge.DTO;
using Model = Knights.Challenge.Domain.Model;

namespace Knights.Challenge.API.Configuration
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<Model.Knight, KnightDto>().ReverseMap();
            CreateMap<Model.Weapon, WeaponDto>().ReverseMap();
            CreateMap<Model.Attribute, AttributeDto>().ReverseMap();
            CreateMap<Model.KnightTraits, KnightTraitsDto>().ReverseMap();            
        }
    }
}
