using Microsoft.EntityFrameworkCore;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using Pokemon.Data.Interfaces.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Business.Services
{
    internal class PokemonFullDetailsService : IPokemonFullDetailsService
    {
        private readonly IPokemonDbContext _pokemonDbContext;

        public PokemonFullDetailsService(IPokemonDbContext pokemonDbContext)
        {
            _pokemonDbContext = pokemonDbContext;
        }

        public async Task<IEnumerable<PokemonFullDetails>> GetAllPokemonFullDetailsAsync()
        {
            var pokemonList =
                from pokemon in _pokemonDbContext.SourcePokemon
                select new PokemonFullDetails()
                {
                    Id = pokemon.Id,
                    Number = pokemon.Number,
                    Name = pokemon.Name,
                    Species = (SourceSpecies)pokemon.SpeciesId,
                    PokemonTypeList = pokemon.PokemonTypeList.Select(pt => (SourcePokemonTypeEnum)pt.TypeId),
                    NormalAbilities = pokemon.PokemonAbilityList
                        .Where(pa => (SourceAbilityKind)pa.AbilityKind == SourceAbilityKind.Normal)
                        .Select(pa => pa.Ability.Description),
                    HiddenAbilities = pokemon.PokemonAbilityList
                        .Where(pa => (SourceAbilityKind)pa.AbilityKind == SourceAbilityKind.Hidden)
                        .Select(pa => pa.Ability.Description),
                    PokemonEggGroupList = pokemon.PokemonEggGroupList.Select(peg => (SourceEggGroup)peg.EggGroupId),
                    PercentageMales = pokemon.PercentageMales,
                    PercentageFemales = pokemon.PercentageFemales,
                    Height = pokemon.Height,
                    Weight = pokemon.Weight,
                    FamilyId = pokemon.Family.FamilyNumber,
                    EvolutionStage = pokemon.EvolutionStage,
                    EvolutionLine = pokemon.Family.PokemonList.Select(p => p.Name),
                    IsStarter = pokemon.IsStarter,
                    IsLegendary = pokemon.IsLegendary,
                    IsMythical = pokemon.IsMythical,
                    IsUltraBeast = pokemon.IsUltraBeast,
                    IsMega = pokemon.IsMega,
                    Generation = pokemon.Gen,
                };
            return await pokemonList.ToListAsync();
        }

        public async Task<PokemonFullDetails> GetPokemonFullDetailsByNumberAsync(int number)
        {
            var pokemonList =
                from pokemon in _pokemonDbContext.SourcePokemon
                select new PokemonFullDetails()
                {
                    Id = pokemon.Id,
                    Number = pokemon.Number,
                    Name = pokemon.Name,
                    Species = (SourceSpecies)pokemon.SpeciesId,
                    PokemonTypeList = pokemon.PokemonTypeList.Select(pt => (SourcePokemonTypeEnum)pt.TypeId),
                    NormalAbilities = pokemon.PokemonAbilityList
                        .Where(pa => (SourceAbilityKind)pa.AbilityKind == SourceAbilityKind.Normal)
                        .Select(pa => pa.Ability.Description),
                    HiddenAbilities = pokemon.PokemonAbilityList
                        .Where(pa => (SourceAbilityKind)pa.AbilityKind == SourceAbilityKind.Hidden)
                        .Select(pa => pa.Ability.Description),
                    PokemonEggGroupList = pokemon.PokemonEggGroupList.Select(peg => (SourceEggGroup)peg.EggGroupId),
                    PercentageMales = pokemon.PercentageMales,
                    PercentageFemales = pokemon.PercentageFemales,
                    Height = pokemon.Height,
                    Weight = pokemon.Weight,
                    FamilyId = pokemon.Family.FamilyNumber,
                    EvolutionStage = pokemon.EvolutionStage,
                    EvolutionLine = pokemon.Family.PokemonList.Select(p => p.Name),
                    IsStarter = pokemon.IsStarter,
                    IsLegendary = pokemon.IsLegendary,
                    IsMythical = pokemon.IsMythical,
                    IsUltraBeast = pokemon.IsUltraBeast,
                    IsMega = pokemon.IsMega,
                    Generation = pokemon.Gen,
                };
            return await pokemonList.FirstOrDefaultAsync(sp => sp.Number == number);
        }
    }
}
