using Pokemon.Data.Interfaces.DatabaseEntities;
using Pokemon.Data.Interfaces.Enums;
using System.Collections.Generic;

namespace Pokemon.Data.EntityFramework.Seed
{
    internal static class SourcePokemonAbilityList
    {
        internal static IEnumerable<SourcePokemonAbility> GetSourcePokemonAbilityList()
        {
            return new List<SourcePokemonAbility>()
            {
                new ()
                {
                    Id = 1,
                    PokemonId = 1,
                    AbilityId = 1,
                    AbilityKind = (int)SourceAbilityKind.Normal,
                },
                new ()
                {
                    Id = 2,
                    PokemonId = 1,
                    AbilityId = 2,
                    AbilityKind = (int)SourceAbilityKind.Hidden,
                }
            };
        }
    }
}
