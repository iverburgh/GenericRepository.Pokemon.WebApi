using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Business.Profiles;
using System;
using Pokemon.Business.Interfaces;
using Pokemon.Data.DependencyInjection;

namespace Pokemon.Business.DependencyInjection
{
    public static class BusinessDependencyInjectionContainerConfiguration
    {
        public static void ConfigureBusinessDependencyInjectionContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(PokemonProfile).Assembly);
            services.AddTransient<IPokemonBl, PokemonBl>();
            services.ConfigureDataDependencyInjectionContainer(configuration);
        }

    }
}
