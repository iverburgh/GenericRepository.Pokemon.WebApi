using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Business.Interfaces
{
    public interface IPokemonBl
    {
        Task<bool> CreatePokemonAsync(Pokemon pokemon);
        Task<IEnumerable<Pokemon>> GetAllPokemonAsync();
        Task<Interfaces.Pokemon> GetPokemonByNumberAsync(int number);
        Task<bool> UpdatePokemonAsync(Pokemon pokemon);
        Task<bool> DeletePokemonAsync(Pokemon pokemon);
    }
}
