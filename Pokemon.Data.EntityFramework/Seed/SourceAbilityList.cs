using Pokemon.Data.Interfaces;
using System.Collections.Generic;

namespace Pokemon.Data.EntityFramework.Seed
{
    internal static class SourceAbilityList
    {
        internal static IEnumerable<SourceAbility> GetSourceAbilityList()
        {
            return new List<SourceAbility>()
            {
                new ()
                {
                    Id = 1,
                    Description = "Overgrow",
                },
                new ()
                {
                    Id = 2,
                    Description = "Chlorophyll",
                },
            };
        }
    }
}
