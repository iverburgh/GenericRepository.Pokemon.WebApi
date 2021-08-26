using Pokemon.Data.Interfaces.Enums;
using System;

namespace Pokemon.Data.PokeApi.Extensions
{
    public static class SpeciesExtension
    {
        public static SourceSpecies MapToSourceSpecies(this Species species)
        {
            if (Enum.TryParse(species.Name, true, out SourceSpecies sourceSpecies))
            {
                return sourceSpecies;
            }
            return SourceSpecies.Undefined;
        }
    }
}
