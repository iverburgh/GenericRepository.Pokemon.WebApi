using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
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
        private Mock<IRepository<PokemonFullDetails>> _pokemonFullDetailsRepositoryMock;

        public PokemonBlTest()
        {
            _loggerMock = new Mock<ILogger<PokemonBl>>();
            _mapperMock = new Mock<IMapper>();
            _pokemonFullDetailsRepositoryMock = new Mock<IRepository<PokemonFullDetails>>();
            _pokemonBl = new PokemonBl(_loggerMock.Object, _mapperMock.Object,
                _pokemonFullDetailsRepositoryMock.Object);
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
            _pokemonFullDetailsRepositoryMock.Setup(pflr =>
                    pflr.GetSingleByExpressionAsync(It.IsAny<Expression<Func<PokemonFullDetails, bool>>>()))
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
            _pokemonFullDetailsRepositoryMock.Setup(pflr =>
                    pflr.GetAll()).Returns(pokemonFullDetailsList);
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
