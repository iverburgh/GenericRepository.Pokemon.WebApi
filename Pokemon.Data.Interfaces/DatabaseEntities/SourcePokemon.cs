using System.Collections.Generic;
using Pokemon.Data.Interfaces.DatabaseEntities;

namespace Pokemon.Data.Interfaces.DatabaseEntities
{
    public class SourcePokemon : BaseEntity
    {
        public SourcePokemon()
        {
            PokemonTypeList = new HashSet<SourcePokemonType>();
            PokemonAbilityList = new HashSet<SourcePokemonAbility>();
            PokemonEggGroupList = new HashSet<SourcePokemonEggGroup>();
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public double PercentageMales { get; set; }
        public double PercentageFemales { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int FamilyId { get; set; }
        public int EvolutionStage { get; set; }
        public bool IsStarter { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsMythical { get; set; }
        public bool IsUltraBeast { get; set; }
        public bool IsMega { get; set; }
        public int Gen { get; set; }
        public virtual ICollection<SourcePokemonType> PokemonTypeList { get; set; }
        public virtual ICollection<SourcePokemonAbility> PokemonAbilityList { get; set; }
        public virtual ICollection<SourcePokemonEggGroup> PokemonEggGroupList { get; set; }
        public virtual SourceFamily Family { get; set; }
    }
}
