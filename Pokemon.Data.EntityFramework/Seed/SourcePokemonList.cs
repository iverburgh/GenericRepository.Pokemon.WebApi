using Pokemon.Data.Interfaces.DatabaseEntities;
using System.Collections.Generic;

namespace Pokemon.Data.EntityFramework.Seed
{
    internal static class SourcePokemonList
    {
        internal static IEnumerable<SourcePokemon> GetSourcePokemonList()
        {
            return new List<SourcePokemon>()
            {
                new SourcePokemon()
                {
                    Id = 1,
                    Number = 1,
                    Name = "Bulbasaur",
                    SpeciesId = 1,
                    PercentageMales = 87.5,
                    PercentageFemales = 12.5,
                    Height = "2'04\"",
                    Weight = "15.2 lbs.",
                    FamilyId = 1,
                    EvolutionStage = 1,
                    IsStarter = true,
                    IsLegendary = false,
                    IsMythical = false,
                    IsUltraBeast = false,
                    IsMega = false,
                    Gen = 1
                }
            };
        }
    }
}
