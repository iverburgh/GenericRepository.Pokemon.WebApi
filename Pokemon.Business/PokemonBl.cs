using AutoMapper;
using Microsoft.Extensions.Logging;
using Pokemon.Business.Interfaces;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon.Business.Services;
using Pokemon.Data.Interfaces.DatabaseEntities;

namespace Pokemon.Business
{
    internal sealed class PokemonBl : IPokemonBl
    {
        private readonly ILogger<PokemonBl> _logger;
        private readonly IMapper _mapper;
        private readonly IPokemonFullDetailsService _pokemonFullDetailsService;

        public PokemonBl(ILogger<PokemonBl> logger, IMapper mapper, IPokemonFullDetailsService pokemonFullDetailsService)
        {
            _logger = logger;
            _mapper = mapper;
            _pokemonFullDetailsService = pokemonFullDetailsService;
        }

        public async Task<bool> CreatePokemonAsync(Interfaces.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<Interfaces.Pokemon> GetPokemonByNumberAsync(int number)
        {
            _logger.LogInformation($"Start handling {nameof(GetPokemonByNumberAsync)}, getting Pokemon by number");
            Interfaces.Pokemon pokemon = null;
            try
            {
                var pokemonFullDetails =
                    await _pokemonFullDetailsService.GetPokemonFullDetailsByNumberAsync(number);
                pokemon = _mapper.Map<Interfaces.Pokemon>(pokemonFullDetails);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Exception occurred in {nameof(GetPokemonByNumberAsync)}: {{Message}}", exception.Message);
                pokemon = null;
            }
            _logger.LogInformation($"Finished handling {nameof(GetAllPokemonAsync)}, returning " +
                                   $"{(pokemon != null ? string.Empty : "empty ")} Pokemon");
            return pokemon;
        }

        public async Task<IEnumerable<Interfaces.Pokemon>> GetAllPokemonAsync()
        {
            _logger.LogInformation($"Start handling {nameof(GetAllPokemonAsync)}, getting all Pokemon");
            List<Interfaces.Pokemon> pokemonList = null;
            try
            {
                var pokemonFullDetailsList = await _pokemonFullDetailsService.GetAllPokemonFullDetailsAsync();
                pokemonList = _mapper.Map<List<Interfaces.Pokemon>>(pokemonFullDetailsList);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Exception occurred in {nameof(GetAllPokemonAsync)}: {{Message}}", exception.Message);
                pokemonList = null;
            }
            _logger.LogInformation($"Finished handling {nameof(GetAllPokemonAsync)}, returning " +
                                   $"{(pokemonList != null ? pokemonList.Count : "empty ")} Pokemon");
            return pokemonList;
        }

        public async Task<bool> UpdatePokemonAsync(Interfaces.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePokemonAsync(Interfaces.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}