namespace Pokemon.Data.Interfaces.DatabaseEntities
{
    public class SourcePokemonAbility : BaseEntity
    {
        public int PokemonId { get; set; }
        public int AbilityKind { get; set; }
        public int AbilityId { get; set; }
        public virtual SourcePokemon Pokemon { get; set; }
        public virtual SourceAbility Ability { get; set; }
    }
}
