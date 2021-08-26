namespace Pokemon.Data.Interfaces.DatabaseEntities
{
    public class SourcePokemonEggGroup : BaseEntity
    {
        public int PokemonId { get; set; }
        public int EggGroupId { get; set; }
        public virtual SourcePokemon Pokemon { get; set; }
    }
}
