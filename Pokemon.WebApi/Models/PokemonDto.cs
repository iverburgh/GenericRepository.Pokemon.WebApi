using System.Collections.Generic;

namespace Pokemon.WebApi.Models
{
    public class PokemonDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public IEnumerable<string> PokemonTypeList { get; set; }
        public IEnumerable<string> NormalAbilities { get; set; }
        public IEnumerable<string> HiddenAbilities { get; set; }
        public IEnumerable<string> EggGroupList { get; set; }
        public double PercentageMales { get; set; }
        public double PercentageFemales { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int FamilyId { get; set; }
        public int EvolutionStage { get; set; }
        public IEnumerable<string> EvolutionLine { get; set; }
        public bool IsStarter { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsMythical { get; set; }
        public bool IsUltraBeast { get; set; }
        public bool IsMega { get; set; }
        public int Generation { get; set; }
    }
}
