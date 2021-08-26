using System.Collections.Generic;
using Pokemon.Data.Interfaces.DatabaseEntities;

namespace Pokemon.Data.Interfaces
{
    public class SourceAbility : BaseEntity
    {
        public SourceAbility()
        {
            SourcePokemonAbilityList = new HashSet<SourcePokemonAbility>();
        }

        public string Description { get; set; }
        public virtual ICollection<SourcePokemonAbility> SourcePokemonAbilityList { get; set; }
    }
}
