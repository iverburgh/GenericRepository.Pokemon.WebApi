using System;
using Pokemon.Data.EntityFramework;
using Pokemon.Data.Interfaces.DatabaseEntities;
using Pokemon.Data.Interfaces.DerivedModels;
using Pokemon.Data.Interfaces.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pokemon.Data.EntityFramework
{
    internal class PokemonFullDetailsEFRepository : EntityFrameworkRepository<PokemonFullDetails>
    {
        public PokemonFullDetailsEFRepository(IPokemonDbContext pokemonDbContext) : base(pokemonDbContext)
        {
        }

        public override Task<PokemonFullDetails> GetSingleByExpressionAsync(Expression<Func<PokemonFullDetails, bool>> expression)
        {
            var pokemonList =
                from pokemon in _pokemonDbContext.Set<SourcePokemon>()
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
            return pokemonList.FirstAsync(expression);
        }
    }
}
