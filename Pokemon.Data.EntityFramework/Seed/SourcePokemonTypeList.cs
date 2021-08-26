using Pokemon.Data.Interfaces.DatabaseEntities;
using System.Collections.Generic;

namespace Pokemon.Data.EntityFramework.Seed
{
    internal static class SourcePokemonTypeList
    {
        internal static IEnumerable<SourcePokemonType> GetSourcePokemonTypeList()
        {
            return new List<SourcePokemonType>()
            {
                new ()
                {
                    Id = 1,
                    PokemonId = 1,
                    TypeId = 1,
                },
                new ()
                {
                    Id = 2,
                    PokemonId = 1,
                    TypeId = 2,
                },
            };
        }
    }
}