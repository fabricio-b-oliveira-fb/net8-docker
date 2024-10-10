using AutoMapper;
using Knights.Challenge.Domain.Model;
using Knights.Challenge.DTO;

namespace Knights.Challenge.API.Configuration
{
    public static class MapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperConfigurationProfile));
        }
    }
}
