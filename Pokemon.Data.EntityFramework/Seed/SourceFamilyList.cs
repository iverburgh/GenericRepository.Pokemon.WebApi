using Pokemon.Data.Interfaces.DatabaseEntities;
using System.Collections.Generic;

namespace Pokemon.Data.EntityFramework.Seed
{
    internal static class SourceFamilyList
    {
        internal static IEnumerable<SourceFamily> GetSourceFamilyList()
        {
            return new List<SourceFamily>()
            {
                new ()
                {
                    Id = 1,
                    FamilyNumber = 1,
                },
            };
        }
    }
}
