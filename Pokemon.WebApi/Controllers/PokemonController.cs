using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Business.Interfaces;
using Pokemon.WebApi.Models;
using System.Threading.Tasks;

namespace Pokemon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPokemonBl _pokemonBl;

        public PokemonController(IMapper mapper, IPokemonBl pokemonBl)
        {
            _mapper = mapper;
            _pokemonBl = pokemonBl;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PokemonDto pokemonDto)
        {
            return Ok(await _pokemonBl.CreatePokemonAsync(_mapper.Map<Business.Interfaces.Pokemon>(pokemonDto)));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PokemonDto>>(await _pokemonBl.GetAllPokemonAsync()));
        }

        [HttpGet]
        [Route("PokemonByNumber")]
        public async Task<IActionResult> Get(int number)
        {
            return Ok(_mapper.Map<PokemonDto>(await _pokemonBl.GetPokemonByNumberAsync(number)));
        }

    }
}
