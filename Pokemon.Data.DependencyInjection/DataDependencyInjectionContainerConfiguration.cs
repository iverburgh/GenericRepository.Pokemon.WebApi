using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Data.EntityFramework;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using Pokemon.Data.PokeApi;
using Pokemon.Data.PokeApi.Profiles;
using RestSharp;

namespace Pokemon.Data.DependencyInjection
{
    public static class DataDependencyInjectionContainerConfiguration
    {
        public static void ConfigureDataDependencyInjectionContainer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<IPokemonDbContext, PokemonDbContext>(options =>
            //{
            //    var connectionString = configuration.GetConnectionString("pokemon");
            //    options.UseSqlServer(connectionString)
            //        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //});
            services.AddDbContext<IPokemonDbContext, PokemonDbContext>(options =>
                options.UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );
            //services.AddTransient(typeof(IRepository<PokemonFullDetails>), typeof(PokemonFullDetailsApiRepository));
            services.AddTransient(typeof(IRepository<PokemonFullDetails>), typeof(PokemonFullDetailsEFRepository));
            services.AddTransient(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddTransient<IRestClient, RestClient>();
            services.AddAutoMapper(typeof(PokeApiPokemonProfile).Assembly);

        }
    }

}
