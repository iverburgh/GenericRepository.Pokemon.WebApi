using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using Newtonsoft.Json;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using RestSharp;

namespace Pokemon.Data.PokeApi
{
    public class PokemonFullDetailsApiRepository : IRepository<PokemonFullDetails>
    {
        private readonly IRestClient _restClient;
        private readonly IMapper _mapper;
        private const string BaseUrl = "https://pokeapi.co/api/v2/";

        public PokemonFullDetailsApiRepository(IRestClient restClient, IMapper mapper)
        {
            _restClient = restClient;
            _mapper = mapper;
            _restClient.BaseUrl = new Uri(BaseUrl);
        }

        public Task<PokemonFullDetails> SaveOrUpdateAsync(PokemonFullDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<PokemonFullDetails> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PokemonFullDetails> GetSingleByExpressionAsync(Expression<Func<PokemonFullDetails, bool>> expression)
        {
            var pokemonNumber = ExpressionUtilities.GetValue(((BinaryExpression)expression.Body).Right).ToString();
            var pokeApiPokemon = await GetPokeApiPokemon(pokemonNumber);
            var pokemonFullDetails = _mapper.Map<PokemonFullDetails>(pokeApiPokemon);
            //var pokeApiSpecies = await GetPokeApiSpecies(pokemonNumber);
            //pokemonFullDetails = _mapper.Map(pokeApiSpecies, pokemonFullDetails);
            return pokemonFullDetails;
        }

        private async Task<PokeApiPokemon> GetPokeApiPokemon(string pokemonNumber)
        {
            var request = new RestRequest($"pokemon/{pokemonNumber}", Method.GET);
            var response = await _restClient.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<PokeApiPokemon>(response.Content);
        }

        private async Task<PokeApiSpecies.Species> GetPokeApiSpecies(string pokemonNumber)
        {
            var request = new RestRequest($"pokemon-species/{pokemonNumber}", Method.GET);
            var response = await _restClient.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<PokeApiSpecies.Species>(response.Content);
        }


        public IEnumerable<PokemonFullDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PokemonFullDetails>> GetByExpressionAsync(Expression<Func<PokemonFullDetails, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Delete(PokemonFullDetails entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}