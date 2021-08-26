using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pokemon.Data.Interfaces.DerivedModels;

namespace Pokemon.Data.PokeApi.Profiles
{
    public class PokeApiSpeciesProfile : Profile
    {
        public PokeApiSpeciesProfile()
        {
            CreateMap<PokeApiSpecies.Species, PokemonFullDetails>();
                //.ForMember(dest => dest.Generation, opt => opt.MapFrom(src => src.Generation.));
        }
    }
}
