using Pokemon.Data.Interfaces.DatabaseEntities;
using System.Collections.Generic;

namespace Pokemon.Data.EntityFramework.Seed
{
    internal static class SourcePokemonEggGroupList
    {
        internal static IEnumerable<SourcePokemonEggGroup> GetSourcePokemonEggGroupList()
        {
            return new List<SourcePokemonEggGroup>()
            {
                new()
                {
                    Id = 1,
                    EggGroupId = 1,
                    PokemonId = 1,
                },
                new()
                {
                    Id = 2,
                    EggGroupId = 2,
                    PokemonId = 1,
                },
            };
        }
    }
}
