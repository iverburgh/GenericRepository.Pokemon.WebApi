using AutoMapper;
using Pokemon.Data.Interfaces.DerivedModels;
using System;
using Pokemon.Data.PokeApi.Extensions;

namespace Pokemon.Data.PokeApi.Profiles
{
    public class PokeApiPokemonProfile : Profile
    {
        public PokeApiPokemonProfile()
        {
            CreateMap<PokeApiPokemon, PokemonFullDetails>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => Convert.ToInt32(src.Id)))
                .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Species.MapToSourceSpecies()));
        }
    }
}
