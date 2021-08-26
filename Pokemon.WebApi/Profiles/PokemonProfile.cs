using AutoMapper;
using Microsoft.OpenApi.Extensions;
using Pokemon.WebApi.Models;
using System.Linq;

namespace Pokemon.WebApi.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<Business.Interfaces.Pokemon, PokemonDto>()
                .ForMember(dest => dest.EggGroupList, opt => opt.MapFrom(src => src.EggGroupList.Select(eg => eg.GetDisplayName())));
        }
    }
}
