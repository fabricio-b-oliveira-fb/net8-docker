using Knights.Challenge.Domain;
using Knights.Challenge.Service;
using Knights.Challenge.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Knights.Challenge.API.Configuration
{
    public static class DIConfiguration
    {
        public static void ServicesRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // App services
            services.AddScoped<IKnightsChallengeService, KnightsChallengeService>();
            services.AddScoped<IKnightsChallengeRepository, KnightsChallengeRepository>();
        }
    }
}
