using System.Collections.Generic;
using Pokemon.Data.Interfaces.DerivedModels;
using System.Threading.Tasks;

namespace Pokemon.Business.Services
{
    internal interface IPokemonFullDetailsService
    {
        Task<PokemonFullDetails> GetPokemonFullDetailsByNumberAsync(int number);
        Task<IEnumerable<PokemonFullDetails>> GetAllPokemonFullDetailsAsync();
    }
}
