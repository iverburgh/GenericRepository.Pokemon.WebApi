namespace Pokemon.Data.Interfaces.DatabaseEntities
{
    public class SourcePokemonType : BaseEntity
    {
        public int PokemonId { get; set; }
        public int TypeId { get; set; }
        public virtual SourcePokemon Pokemon { get; set; }
    }
}
