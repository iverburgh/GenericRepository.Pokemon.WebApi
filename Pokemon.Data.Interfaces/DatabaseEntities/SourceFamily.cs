using System.Collections.Generic;

namespace Pokemon.Data.Interfaces.DatabaseEntities
{
    public class SourceFamily : BaseEntity
    {
        public SourceFamily()
        {
            PokemonList = new HashSet<SourcePokemon>();
        }

        public int FamilyNumber { get; set; }
        public virtual ICollection<SourcePokemon> PokemonList { get; set; }
    }
}
