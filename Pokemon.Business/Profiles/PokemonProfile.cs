using AutoMapper;
using Pokemon.Business.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using Pokemon.Data.Interfaces.Enums;

namespace Pokemon.Business.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<PokemonFullDetails, Interfaces.Pokemon>()
                .ForMember(dest => dest.EggGroupList, opt => opt.MapFrom(src => src.PokemonEggGroupList));

            CreateMap<SourceSpecies, Species>();
            
            CreateMap<SourcePokemonTypeEnum, PokemonType>();

            CreateMap<SourceEggGroup, EggGroup>();

        }
    }
}
