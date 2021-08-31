using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.Business.Services;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Interfaces.DerivedModels;
using Xunit;

namespace Pokemon.Business.Test
{
    public class PokemonBlTest
    {
        private PokemonBl _pokemonBl;
        private Mock<ILogger<PokemonBl>> _loggerMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IPokemonFullDetailsService> _pokemonFullDetailsServiceMock;

        public PokemonBlTest()
        {
            _loggerMock = new Mock<ILogger<PokemonBl>>();
            _mapperMock = new Mock<IMapper>();
            _pokemonFullDetailsServiceMock = new Mock<IPokemonFullDetailsService>();
            _pokemonBl = new PokemonBl(_loggerMock.Object, _mapperMock.Object,
                _pokemonFullDetailsServiceMock.Object);
        }

        [Fact]
        public async Task GetPokemonByNumberAsync_WhenCalled_ReturningObjectAreCorrectlyPassed()
        {
            // arrange
            var pokemonNumber = 1;
            var pokemonFullDetails = new PokemonFullDetails()
            {
                Number = 1,
                Name = "testpokemon"
            };
            var pokemon = new Interfaces.Pokemon()
            {
                Number = 1,
                Name = "testpokemon"
            };
            _pokemonFullDetailsServiceMock.Setup(pflr =>
                    pflr.GetPokemonFullDetailsByNumberAsync(It.IsAny<int>()))
                    .ReturnsAsync(pokemonFullDetails);
            _mapperMock.Setup(mapper => mapper.Map<Interfaces.Pokemon>(It.IsAny<PokemonFullDetails>()))
                .Callback<object>(pokemonFullDetailsParam => pokemonFullDetailsParam.Should().BeEquivalentTo(pokemonFullDetails))
                .Returns(pokemon);
            // act
            var result = await _pokemonBl.GetPokemonByNumberAsync(pokemonNumber);
            // assert
            result.Should().BeEquivalentTo(pokemon);
        }

        [Fact]
        public async Task GetAllPokemonAsync_WhenCalled_ReturningObjectsAreCorrectlyPassed()
        {
            // arrange
            var pokemonFullDetailsList = new List<PokemonFullDetails>()
            {
                new ()
                {
                    Number = 1,
                    Name = "Testpokemon 1"
                },
                new ()
                {
                    Number = 2,
                    Name = "Testpokemon 2"
                }
            };
            var pokemonList = new List<Interfaces.Pokemon>()
            {
                new ()
                {
                    Number = 1,
                    Name = "Testpokemon 1"
                },
                new ()
                {
                    Number = 2,
                    Name = "Testpokemon 2"
                }
            };
            _pokemonFullDetailsServiceMock.Setup(pflr =>
                    pflr.GetAllPokemonFullDetailsAsync()).ReturnsAsync(pokemonFullDetailsList);
            _mapperMock.Setup(mapper => mapper.Map<List<Interfaces.Pokemon>>(It.IsAny<IEnumerable<PokemonFullDetails>>()))
                .Callback<object>(pokemonFullDetailsListParam => pokemonFullDetailsListParam.Should().BeEquivalentTo(pokemonFullDetailsList))
                .Returns(pokemonList);
            // act
            var result = await _pokemonBl.GetAllPokemonAsync();
            // assert
            result.Should().BeEquivalentTo(pokemonList);
        }
    }
}
